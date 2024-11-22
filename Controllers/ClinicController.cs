
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.RequestModels.Clinic;
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

    [HttpGet("get-list-clinic")]
    public IActionResult ListClinic()
    {
        var clinics = _clinicService.GetListClinic();
        return Ok(clinics);
    }
    [HttpPost("list-clinic")]
    public IActionResult ListClinic(ListUserRequest request)
    {
        var response = _clinicService.ListClinic(request);
        return Ok(response);
    }

    [HttpPut("edit-clinic")]
    public IActionResult EditClinic([FromBody] EditClinicRequest request)
    {
        return Ok(_clinicService.EditClinic(request));
    }

    [HttpDelete("delete-clinic/{id}")]
    public IActionResult DeleteClinic(Guid id)
    {
        return Ok(_clinicService.DeleteClinic(id));
    }

    [HttpGet("get-clinic/{id}")]
    public async Task<IActionResult> GetClinic(Guid id)
    {
        return Ok(await _clinicService.GetListDoctorByClinicId(id));
    }
}