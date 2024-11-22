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
    
    [HttpPost("DoctorRegistration")]
    public async Task<IActionResult> DoctorRegistration([FromBody] DoctorRegistrationRequest request)
    {
        var response = await _doctorService.DoctorRegistration(request);
        return Ok(response);
    }
    
    [HttpGet("get-list-doctor")]
    public IActionResult ListDoctor()
    {
        var doctors = _doctorService.ListDoctor();
        return Ok(doctors);
    }
    
    [HttpPost("list-doctor")]
    public IActionResult ListDoctor(ListUserRequest request)
    {
        var response = _doctorService.ListDoctor(request);
        return Ok(response);
    }

    [HttpPut("edit-doctor")]
    public IActionResult EditDoctor([FromBody] EditDoctorRequest request)
    {
        return Ok(_doctorService.EditDoctor(request));
    }

    [HttpGet("get-list-doctor-by-clinicId/{clinicId}")]
    public IActionResult ListDoctorByClinicId(Guid clinicId)
    {
        return Ok(_doctorService.ListDoctorByClinicId(clinicId));
    }

    [HttpGet("get-doctor-by-id/{id}")]
    public IActionResult GetDoctorById(Guid id)
    {
        return Ok(_doctorService.GetDoctorById(id));
    }

    [HttpDelete("delete-doctor/{id}")]
    public IActionResult DeleteDoctor(Guid id)
    {
        return Ok(_doctorService.DeleteDoctor(id));
    }
    
    
}