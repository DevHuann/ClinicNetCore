using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.RequestModels.TreatmentType;
using ClinicNetCore.Models.ResponseModels.Doctor;
using ClinicNetCore.Models.ResponseModels.TreatmentType;
using Microsoft.AspNetCore.Identity;

namespace ClinicNetCore.Services.Impl;

public class DoctorService : IDoctorService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    
    public DoctorService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
        IConfiguration configuration, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _context = context;
    }
    public async Task<bool> DoctorRegistration(DoctorRegistrationRequest request)
    {
        var doctor = new Doctor()
        {
            Id = Guid.NewGuid(),
            UserName = request.Email,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            FullName = request.FullName,
            Address = request.Address,
            DoctorAvatar = request.DoctorAvatar,
            DoctorSpeciality = request.DoctorSpeciality,
            DoctorExperience = request.DoctorExperience,
            DoctorDescription = request.DoctorDescription,
            DoctorSpokenLanguages = request.DoctorSpokenLanguages,
            DoctorGender = request.DoctorGender,
            DoctorDob = request.DoctorDob,
            ConsultFee = request.ConsultFee,
            ClinicId = request.ClinicId,
            DateCreated = DateTime.UtcNow,
        };
        var newClinic = await _userManager.CreateAsync(doctor, request.Password);
        await _userManager.AddToRolesAsync(doctor, ["Doctor"]);
        if (!newClinic.Succeeded) return false;
        return true;
    }

    public List<ListDoctorResponse> ListDoctor()
    {
        var doctors = _context.Doctors.Select(doctor => new ListDoctorResponse
        {
            Id = doctor.Id,
            PhoneNumber = doctor.PhoneNumber,
            Email = doctor.Email,
            FullName = doctor.FullName,
            Address = doctor.Address,
            DoctorAvatar = doctor.DoctorAvatar,
            DoctorSpeciality = doctor.DoctorSpeciality,
            DoctorExperience = doctor.DoctorExperience,
            DoctorDescription = doctor.DoctorDescription,
            DoctorSpokenLanguages = doctor.DoctorSpokenLanguages,
            DoctorGender = doctor.DoctorGender,
            DoctorDob = doctor.DoctorDob,
            ConsultFee = doctor.ConsultFee,
            ClinicId = doctor.ClinicId,
            DateCreated = doctor.DateCreated
        }).ToList();
        return doctors;
    }

    public DoctorResponse ListDoctor(ListUserRequest request)
    {
        var allDoctor = _userManager.Users.OfType<Doctor>().AsQueryable();
        if (!string.IsNullOrEmpty(request.Search))
        {
            allDoctor = allDoctor.Where(doctor => doctor.FullName.ToLower().Contains(request.Search.ToLower()));
        }
        var result = PaginatedList<Doctor>
            .Create(allDoctor,request.PageIndex,request.PageSize);
        var listDoctor = result.Select(doctor => new ListDoctorResponse()
        {
            Id = doctor.Id,
            PhoneNumber = doctor.PhoneNumber,
            Email = doctor.Email,
            FullName = doctor.FullName,
            Address = doctor.Address,
            DoctorAvatar = doctor.DoctorAvatar,
            DoctorSpeciality = doctor.DoctorSpeciality,
            DoctorExperience = doctor.DoctorExperience,
            DoctorDescription = doctor.DoctorDescription,
            DoctorSpokenLanguages = doctor.DoctorSpokenLanguages,
            DoctorGender = doctor.DoctorGender,
            DoctorDob = doctor.DoctorDob,
            ConsultFee = doctor.ConsultFee,
            ClinicId = doctor.ClinicId,
            DateCreated = doctor.DateCreated
        }).ToList();
        return new DoctorResponse
        {
            ListDoctor = listDoctor,
            TotalPage = result.TotalPage,
            PageIndex = result.PageIndex,
            PageSize = result.PageSize,
            TotalRecords = allDoctor.Count()
        };
    }

    public EditDoctorResponse EditDoctor(EditDoctorRequest request)
    {
        var editDoctor = _context.Doctors.FirstOrDefault(d => d.Id == request.Id);
        if (editDoctor==null)
        {
            throw new Exception("Doctor not exist!!");
        }
        editDoctor.PhoneNumber = request.PhoneNumber;
        editDoctor.FullName = request.FullName;
        editDoctor.Address = request.Address;
        editDoctor.DoctorAvatar = request.DoctorAvatar;
        editDoctor.DoctorSpeciality = request.DoctorSpeciality;
        editDoctor.DoctorExperience = request.DoctorExperience;
        editDoctor.DoctorDescription = request.DoctorDescription;
        editDoctor.DoctorSpokenLanguages = request.DoctorSpokenLanguages;
        editDoctor.DoctorGender = request.DoctorGender;
        editDoctor.DoctorDob = request.DoctorDob;
        editDoctor.ConsultFee = request.ConsultFee;
        editDoctor.ClinicId = request.ClinicId;
        _context.SaveChanges();
        return new EditDoctorResponse
        {
            PhoneNumber = editDoctor.PhoneNumber,
            Email = editDoctor.Email,
            FullName = editDoctor.FullName,
            Address = editDoctor.Address,
            DoctorAvatar = editDoctor.DoctorAvatar,
            DoctorSpeciality = editDoctor.DoctorSpeciality,
            DoctorExperience = editDoctor.DoctorExperience,
            DoctorDescription = editDoctor.DoctorDescription,
            DoctorSpokenLanguages = editDoctor.DoctorSpokenLanguages,
            DoctorGender = editDoctor.DoctorGender,
            DoctorDob = editDoctor.DoctorDob,
            ConsultFee = editDoctor.ConsultFee,
            DateCreated = editDoctor.DateCreated
        };
    }

    public List<Doctor> ListDoctorByClinicId(Guid clinicId)
    {
        var doctors = _context.Doctors
            .Where(d => d.ClinicId == clinicId).ToList();
        if (doctors == null)
        {
            throw new Exception("null");
        }

        return doctors;
        {
            
        }
    }

    public Doctor GetDoctorById(Guid id)
    {
        var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
        if (doctor == null)
        {
            throw new Exception("Doctor not exist");
        }

        return doctor;
    }

    public bool DeleteDoctor(Guid id)
    {
        var delDoctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
        if (delDoctor==null)
        {
            throw new Exception("Doctor not exist!!");
        }
        _context.Remove(delDoctor);
        _context.SaveChanges();
        return true;
    }
    
}