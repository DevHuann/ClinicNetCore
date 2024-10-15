using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;
[ApiController]
[Route("[controller]")]
public class PatientController:ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    
    [HttpPost("PatientRegistration")]
    public async Task<IActionResult> PatientRegistration([FromBody] PatientRegistrationRequest request)
    {
        var response = await _patientService.PatientRegistration(request);
        return Ok(response);
    }
    
    [HttpGet("list-Patient")]
    public IActionResult ListPatient()
    {
        var patient = _patientService.ListPatient();
        return Ok(patient);
    }
}