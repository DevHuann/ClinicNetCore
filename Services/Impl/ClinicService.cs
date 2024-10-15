using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;

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
        // Lấy thời gian hiện tại ở UTC
        DateTime utcNow = DateTime.UtcNow;

        // Chuyển đổi thời gian UTC hiện tại sang múi giờ UTC+7
        // Lưu ý: Đây chỉ là cách tạm thời và không chính xác trong mọi trường hợp
        DateTime localTime = utcNow.AddHours(7);
        var clinic = new Clinic()
        {
            Id = Guid.NewGuid(),
            UserName = request.Email,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            FullName = request.FullName,
            Address = request.Address,
            ClinicName = request.ClinicName,
            ClinicUrl = request.ClinicUrl,
            ClinicZipcode = request.ClinicZipcode,
            ClinicStatus = 0,
            DateCreated = localTime
        };
        var newClinic = await _userManager.CreateAsync(clinic, request.Password);
        if (!newClinic.Succeeded) return false;
        await _userManager.AddToRolesAsync(clinic, ["Clinic"]);
        return true;
    }

    public List<ListClinicResponse> ListClinic()
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
            ClinicZipcode = clinic.ClinicZipcode,
            DateCreated = clinic.DateCreated

        }).ToList();
        return clinics;
    }
}