using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
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

    [HttpGet("get-list-patient")]
    public IActionResult ListPatient()
    {
        var patient = _patientService.ListPatient();
        return Ok(patient);
    }

    [HttpPost("list-patient")]
    public IActionResult ListPatient(ListUserRequest request)
    {
        var response = _patientService.ListPatient(request);
        return Ok(response);
    }

    [HttpGet("list-patient-by-doctor-id/{id}")]
    public IActionResult ListPatientByDoctorId(Guid id)
    {
        var response = _patientService.ListPatientByDoctorId(id);
        return Ok(response);
    }

    [HttpGet("list-patient-by-clinic-id/{id}")]
    public IActionResult ListPatientByClinicId(Guid id)
    {
        var response = _patientService.ListPatientByClinicId(id);
        return Ok(response);
    }
    [HttpGet("get-patient-by-id/{id}")]
    public IActionResult GetPatientById(Guid id)
    {
        return Ok(_patientService.GetPatientById(id));
    }
}