using ClinicNetCore.Models.RequestModels.Speciality;
using ClinicNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;

public class SpecialityController: ControllerBase
{
    private readonly ISpecialityService _specialityService;

    public SpecialityController(ISpecialityService specialityService)
    {
        _specialityService = specialityService;
    }

    [HttpGet("get-list-speciality")]
    public IActionResult GetListSpeciality()
    {
        var specialities = _specialityService.GetListSpeciality();
        return Ok(specialities);
    }

    [HttpPost("create-speciality")]
    public IActionResult CreateSpeciality([FromBody]CreateSpecialityRequest request)
    {
        var speciality = _specialityService.CreateSpeciality(request);
        return Ok(speciality);
    }

    [HttpPost("edit-speciality")]
    public IActionResult EditSpeciality([FromBody] EditSpecialityRequest request)
    {
        var editSpeciality = _specialityService.EditSpeciality(request);
        return Ok(editSpeciality);
    }

    [HttpDelete("delete-spaciality/{id}")]
    public IActionResult DeleteSpciality(Guid id)
    {
        var isDeleteSpeciality = _specialityService.DeleteSpeciality(id);
        return Ok(isDeleteSpeciality);
    }
}