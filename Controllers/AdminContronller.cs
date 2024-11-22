using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;
using ClinicNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;
[ApiController]
[Route("controller")]
public class AdminContronller:ControllerBase
{
    private readonly IClinicService _clinicService;
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;


    public AdminContronller(IClinicService clinicService, IDoctorService doctorService, IPatientService patientService)
    {
        _clinicService = clinicService;
        _doctorService = doctorService;
        _patientService = patientService;
    }
    
    
    

}