using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;

namespace ClinicNetCore.Services.Impl;

public class PatientService : IPatientService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    
    public PatientService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
        IConfiguration configuration, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _context = context;
    }
    public async Task<bool> PatientRegistration(PatientRegistrationRequest request)
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
            DateCreated = DateTime.Now
        };
        var newClinic = await _userManager.CreateAsync(patient, request.Password);
        if (!newClinic.Succeeded) return false;
        await _userManager.AddToRolesAsync(patient, ["Patient"]);
        return true;
    }

    public List<ListPatientResponse> ListPatient()
    {
        // Lấy thời gian hiện tại ở UTC
        DateTime utcNow = DateTime.UtcNow;

        // Chuyển đổi thời gian UTC hiện tại sang múi giờ UTC+7
        // Lưu ý: Đây chỉ là cách tạm thời và không chính xác trong mọi trường hợp
        DateTime localTime = utcNow.AddHours(7);
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
            DateCreated = localTime
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