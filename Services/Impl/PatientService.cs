using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels.Patient;
using Microsoft.AspNetCore.Identity;

namespace ClinicNetCore.Services.Impl;

public class PatientService : IPatientService
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ApplicationDbContext _context;
    
    public PatientService(UserManager<ApplicationUser> userManager,
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    public async Task<IdentityResult> PatientRegistration(PatientRegistrationRequest request)
    {
        var patient = new Patient()
        {
            Id = Guid.NewGuid(),
            UserName = request.Email,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            FullName = request.FullName,
            Address = request.Address,
            PatientAvatar =request.PatientAvatar,
            PatientIdentity = request.PatientIdentity,
            PatientNationality = request.PatientNationality,
            PatientGender = request.PatientGender,
            PatientMaritalStatus = request.PatientMaritalStatus,
            PatientDob = request.PatientDob,
            PatientAge = CalculateAge(request.PatientDob),
            DateCreated = DateTime.UtcNow,  
        };
        var newDoctor = await _userManager.CreateAsync(patient, request.Password);
        await _userManager.AddToRolesAsync(patient, ["Patient"]);
        if (!newDoctor.Succeeded) return newDoctor;;
        return IdentityResult.Success;
    }

    public List<ListPatientResponse> ListPatient()
    {
        var patients = _context.Patients.Select(patient => new ListPatientResponse
        {
            Id = patient.Id,
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email,
            FullName = patient.FullName,
            Address = patient.Address,
            PatientAvatar = patient.PatientAvatar,
            PatientIdentity = patient.PatientIdentity,
            PatientNationality = patient.PatientNationality,
            PatientGender = patient.PatientGender,
            PatientMaritalStatus = patient.PatientMaritalStatus,
            PatientDob = patient.PatientDob,
            PatientAge = patient.PatientAge,
            DateCreated = patient.DateCreated
        }).ToList();
        return patients;
    }

    public PatientResponse ListPatient(ListUserRequest request)
    {
        var allPatient = _userManager.Users.OfType<Patient>().AsQueryable();
        if (!string.IsNullOrEmpty(request.Search))
        {
            allPatient = allPatient.Where(doctor => doctor.FullName.ToLower().Contains(request.Search.ToLower()));
        }
        var result = PaginatedList<Patient>
            .Create(allPatient,request.PageIndex,request.PageSize);
        var listPatient = result.Select(patient => new ListPatientResponse
        {
            Id = patient.Id,
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email,
            FullName = patient.FullName,
            Address = patient.Address,
            PatientAvatar = patient.PatientAvatar,
            PatientIdentity = patient.PatientIdentity,
            PatientNationality = patient.PatientNationality,
            PatientGender = patient.PatientGender,
            PatientMaritalStatus = patient.PatientMaritalStatus,
            PatientDob = patient.PatientDob,
            PatientAge = patient.PatientAge,
            DateCreated = patient.DateCreated
        }).ToList();
        return new PatientResponse
        {
            ListPatient = listPatient,
            TotalPage = result.TotalPage,
            PageIndex = result.PageIndex,
            PageSize = result.PageSize,
            TotalRecords = allPatient.Count()
        };
    }

    public Patient GetPatientById(Guid id)
    {
        var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
        if (patient==null)
        {
            throw new Exception("Patient not exist!!");
        }

        return patient;
    }

    public List<ListPatientResponse> ListPatientByDoctorId(Guid id)
    {
        var patients = _context.Appointments
            .Where(appointment => appointment.DoctorId == id)
            .Select(appointment => appointment.Patient)
            .Distinct()
            .Select(patient => new ListPatientResponse
            {
                Id = patient.Id,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                FullName = patient.FullName,
                Address = patient.Address,
                PatientAvatar = patient.PatientAvatar,
                PatientIdentity = patient.PatientIdentity,
                PatientNationality = patient.PatientNationality,
                PatientGender = patient.PatientGender,
                PatientMaritalStatus = patient.PatientMaritalStatus,
                PatientDob = patient.PatientDob,
                PatientAge = patient.PatientAge,
                DateCreated = patient.DateCreated
            }).ToList();

        return patients;
    }

    public List<ListPatientResponse> ListPatientByClinicId(Guid id)
    {
        var patients = _context.Appointments
            .Where(appointment => appointment.ClinicId == id)
            .Select(appointment => appointment.Patient)
            .Distinct()
            .Select(patient => new ListPatientResponse
            {
                Id = patient.Id,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                FullName = patient.FullName,
                Address = patient.Address,
                PatientAvatar = patient.PatientAvatar,
                PatientIdentity = patient.PatientIdentity,
                PatientNationality = patient.PatientNationality,
                PatientGender = patient.PatientGender,
                PatientMaritalStatus = patient.PatientMaritalStatus,
                PatientDob = patient.PatientDob,
                PatientAge = patient.PatientAge,
                DateCreated = patient.DateCreated
            }).ToList();

        return patients;
    }


    private int CalculateAge(DateTime dob)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - dob.Year;
        
        if (today.Month < dob.Month || (today.Month == dob.Month && today.Day < dob.Day))
        {
            age--;
        }

        return age;
    }
}