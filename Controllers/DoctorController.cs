using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;
[ApiController]
[Route("[controller]")]
public class DoctorController:ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    //Doctor
    [HttpPost("DoctorRegistration")]
    public async Task<IActionResult> DoctorRegistration([FromBody] DoctorRegistrationRequest request)
    {
        var response = await _doctorService.DoctorRegistration(request);
        return Ok(response);
    }
    
    [HttpGet("list-Doctor")]
    public IActionResult ListDoctor()
    {
        var doctors = _doctorService.ListDoctor();
        return Ok(doctors);
    }
}