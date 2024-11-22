using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.RequestModels.Clinic;
using ClinicNetCore.Models.ResponseModels.Clinic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicNetCore.Services.Impl;

public class ClinicService : IClinicService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    
    public ClinicService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;

        _context = context;
    }
    public async Task<bool> ClinicRegistration(ClinicRegistrationRequest request)
    {
        var clinic = new Clinic()
        {
            Id = Guid.NewGuid(),
            UserName = request.Email,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Address = request.Address,
            FullName = request.FullName,
            ClinicName = request.ClinicName,
            ClinicUrl = request.ClinicUrl,
            ClinicZipcode = request.ClinicZipcode,
            OpenWeek = request.OpenWeek,
            CloseWeek = request.CloseWeek,
            OpenSat  = request.OpenSat,
            CloseSat  = request.CloseSat,
            OpenSun  = request.OpenSun,
            CloseSun  = request.CloseSun,
            ClinicStatus = 0,
            DateCreated = DateTime.UtcNow,
        };
        var newClinic = await _userManager.CreateAsync(clinic, request.Password);
        await _userManager.AddToRolesAsync(clinic, ["Clinic"]);
        if (!newClinic.Succeeded) return false;
        return true;
    }

    public List<ListClinicResponse> GetListClinic()
    {
        var clinics = _context.Clinics.Select(clinic => new ListClinicResponse
        {
            Id = clinic.Id,
            Email = clinic.Email,
            PhoneNumber = clinic.PhoneNumber,
            Address = clinic.Address,
            FullName = clinic.FullName,
            ClinicName = clinic.ClinicName,
            ClinicUrl = clinic.ClinicUrl,
            OpenWeek = clinic.OpenWeek,
            CloseWeek = clinic.CloseWeek,
            OpenSat  = clinic.OpenSat,
            CloseSat  = clinic.CloseSat,
            OpenSun  = clinic.OpenSun,
            CloseSun  = clinic.CloseSun,
            DateCreated = clinic.DateCreated

        }).ToList();
        return clinics;
    }

    public ClinicResponse ListClinic(ListUserRequest request)
    {
        var allClinic = _userManager.Users.OfType<Clinic>().AsQueryable();
        if (!string.IsNullOrEmpty(request.Search))
        {
            allClinic = allClinic.Where(clinic => clinic.ClinicName.ToLower().Contains(request.Search.ToLower()));
        }
        var result = PaginatedList<Clinic>
            .Create(allClinic,request.PageIndex,request.PageSize);
        var listClinic = result.Select(clinic => new ListClinicResponse()
        {
            Id = clinic.Id,
            Email = clinic.Email,
            PhoneNumber = clinic.PhoneNumber,
            Address = clinic.Address,
            FullName = clinic.FullName,
            ClinicName = clinic.ClinicName,
            ClinicUrl = clinic.ClinicUrl,
            OpenWeek = clinic.OpenWeek,
            CloseWeek = clinic.CloseWeek,
            OpenSat  = clinic.OpenSat,
            CloseSat  = clinic.CloseSat,
            OpenSun  = clinic.OpenSun,
            CloseSun  = clinic.CloseSun,
            DateCreated = clinic.DateCreated
        }).ToList();
        return new ClinicResponse
        {
            ListClinic = listClinic,
            TotalPage = result.TotalPage,
            PageIndex = result.PageIndex,
            PageSize = result.PageSize,
            TotalRecords = allClinic.Count()
        };
    }

    public EditClinicResponse EditClinic(EditClinicRequest request)
    {
        var editClinic = _context.Clinics.FirstOrDefault(c => c.Id == request.Id);
        if (editClinic == null)
        {
            throw new Exception("Clinic not exist!!");
        }
        
        editClinic.PhoneNumber = request.PhoneNumber;
        editClinic.Address = request.Address;
        editClinic.FullName = request.FullName;
        editClinic.ClinicName = request.ClinicName;
        editClinic.ClinicUrl = request.ClinicUrl;
        editClinic.OpenWeek = request.OpenWeek;
        editClinic.CloseWeek = request.CloseWeek;
        editClinic.OpenSat  = request.OpenSat;
        editClinic.CloseSat  = request.CloseSat;
        editClinic.OpenSun  = request.OpenSun;
        editClinic.CloseSun  = request.CloseSun;
        _context.SaveChanges();
        return new EditClinicResponse
        {
            Id = editClinic.Id,
            Email = editClinic.Email,
            PhoneNumber = editClinic.PhoneNumber,
            Address = editClinic.Address,
            FullName = editClinic.FullName,
            ClinicName = editClinic.ClinicName,
            ClinicUrl = editClinic.ClinicUrl,
            OpenWeek = editClinic.OpenWeek,
            CloseWeek = editClinic.CloseWeek,
            OpenSat  = editClinic.OpenSat,
            CloseSat  = editClinic.CloseSat,
            OpenSun  = editClinic.OpenSun,
            CloseSun  = editClinic.CloseSun,
            DateCreated = editClinic.DateCreated
        };

    }

    public bool DeleteClinic(Guid id)
    {
        var delClinic = _context.Clinics.FirstOrDefault(c => c.Id == id);
        if (delClinic == null)
        {
            throw new Exception("Clinic not exist!!");
        }

        _context.Remove(delClinic);
        _context.SaveChanges();
        return true;
    }

    public async Task<GetListDoctorWithClinicIdResponse> GetListDoctorByClinicId(Guid clinicId)
    {
        var clinic = await _context.Clinics
            .Include(c => c.Doctors)
            .FirstOrDefaultAsync(c => c.Id == clinicId);
        if (clinic == null)
        {
            // Xử lý trường hợp không tìm thấy học kỳ
            throw new Exception("Clinic not exist!");
        }

        return new GetListDoctorWithClinicIdResponse
        {
            Id = clinic.Id,
            Email = clinic.Email,
            PhoneNumber = clinic.PhoneNumber,
            Address = clinic.Address,
            FullName = clinic.FullName,
            ClinicName = clinic.ClinicName,
            ClinicUrl = clinic.ClinicUrl,
            ClinicZipcode = clinic.ClinicZipcode,
            OpenWeek = clinic.OpenWeek,
            CloseWeek = clinic.CloseWeek,
            OpenSat = clinic.OpenSat,
            CloseSat = clinic.CloseSat,
            OpenSun = clinic.OpenSun,
            CloseSun = clinic.CloseSun,
            Doctors = clinic.Doctors
        };

    }
}