using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;
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
        // Lấy thời gian hiện tại ở UTC
        DateTime utcNow = DateTime.UtcNow;

        // Chuyển đổi thời gian UTC hiện tại sang múi giờ UTC+7
        // Lưu ý: Đây chỉ là cách tạm thời và không chính xác trong mọi trường hợp
        DateTime localTime = utcNow.AddHours(7);
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
            DateCreated = localTime
        };
        var newClinic = await _userManager.CreateAsync(doctor, request.Password);
        if (!newClinic.Succeeded) return false;
        await _userManager.AddToRolesAsync(doctor, ["Doctor"]);
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
}