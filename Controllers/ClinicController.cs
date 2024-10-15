
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;
[ApiController]
[Route("[controller]")]
public class ClinicController:ControllerBase
{
    private readonly IClinicService _clinicService;
    
    public ClinicController(IClinicService clinicService )
    {
        _clinicService = clinicService;
    }
    
    [HttpPost("clinicRegistration")]
    public async Task<IActionResult> ClinicRegistration([FromBody] ClinicRegistrationRequest request)
    {
        var response = await _clinicService.ClinicRegistration(request);
        return Ok(response);
    }

    [HttpGet("list-Clinic")]
    public IActionResult ListClinic()
    {
        var clinics = _clinicService.ListClinic();
        return Ok(clinics);
    }
}