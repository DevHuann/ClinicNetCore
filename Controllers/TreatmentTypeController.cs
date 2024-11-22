using ClinicNetCore.Models.RequestModels.TreatmentType;
using ClinicNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;

public class TreatmentTypeController:ControllerBase
{
    private readonly ITreatmentTypeService _treatmentTypeService;

    public TreatmentTypeController(ITreatmentTypeService treatmentTypeService)
    {
        _treatmentTypeService = treatmentTypeService;
    }
    
    [HttpGet("get-list-treatmentType-by-doctorId/{id}")]
    public IActionResult GetListTreatmentTypeByDoctorId(Guid id)
    {
        return Ok(_treatmentTypeService.ListTreatmentTypeByDoctorId(id));
    }

    [HttpPost("creat-treatmentType")]
    public IActionResult CreatTreatmentType([FromBody] CreateTreatmentTypeRequest request)
    {
        return Ok(_treatmentTypeService.CreateTreatmentType(request));
    }

    [HttpPost("edit-treatmentType")]
    public IActionResult EditTreatmentType([FromBody] EditTreatmentTypeRequest request)
    {
        return Ok(_treatmentTypeService.EditTreatmentType(request));
    }

    [HttpDelete("delete-treatmentType/{id}")]
    public IActionResult DeleteTreatmentType(Guid id)
    {
        return Ok(_treatmentTypeService.DeleteTreatmentType(id));
    }
    
}