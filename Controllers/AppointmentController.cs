using ClinicNetCore.Models.RequestModels.Appointment;
using ClinicNetCore.Services;
using ClinicNetCore.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;

public class AppointmentController:ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost("create-appointment")]
    public IActionResult CreateAppointment([FromBody]CreateAppointmentRequest request)
    {
        return Ok(_appointmentService.CreateAppointment(request));
    }
    
    [HttpPost("doctor-create-appointment")]
    public IActionResult DoctorCreateAppointment([FromBody]CreateAppointmentRequest request)
    {
        return Ok(_appointmentService.DoctorCreateAppointment(request));
    }

    [HttpPut("confirm-consult-status")]
    public IActionResult ConfirmConsultStatus(Guid id)
    {
        return Ok(_appointmentService.ConfirmConsultStatus(id));
    }
    [HttpPut("confirm-arrive-status")]
    public IActionResult ConfirmArriveStatus(Guid id)
    {
        return Ok(_appointmentService.ConfirmArriveStatus(id));
    }
    [HttpPut("confirm-status")]
    public IActionResult ConfirmStatus(Guid id)
    {
        return Ok(_appointmentService.ConfirmStatus(id));
    }

    [HttpDelete("delete-appointment/{id}")]
    public IActionResult DeleteAppointment(Guid id)
    {
        return Ok(_appointmentService.DeleteAppointment(id));
    }

    [HttpGet("list-appointment-by-patient-id/{id}")]
    public IActionResult GetListAppointmentByPatientId(Guid id)
    {
        return Ok(_appointmentService.GetListAppointmentByPatientId(id));
    }

    [HttpGet("get-list-appointment-by-doctor-id-and-date-and-not-yet-confirmed")]
    public IActionResult GetListAppointmentByDoctorIdAndDateAndNotYetConfirmed(Guid id,DateTime date)
    {
        return Ok(_appointmentService.GetListAppointmentsByDoctorIdAndDateAndNotyetConfirmed(id, date));
    }
    [HttpGet("get-list-appointment-by-clinic-id-and-date-and-not-yet-confirmed")]
    public IActionResult GetListAppointmentByClinicIdAndDateAndNotYetConfirmed(Guid id,DateTime date)
    {
        return Ok(_appointmentService.GetListAppointmentsByClinicIdAndDateAndNotyetConfirmed(id, date));
    }
    
    [HttpPost("list-appointment-by-doctor-id-and-period")]
    public IActionResult GetListAppointmentByDoctorIdAndPeriod([FromBody]ListAppointmentByDoctorIdAndPeriodRequest request)
    {
        return Ok(_appointmentService.GetListAppointmentByDoctorIdAndPeriod(request));
    }
    [HttpPost("list-appointment-by-clinic-id-and-period")]
    public IActionResult GetListAppointmentByClinicIdAndPeriod([FromBody]ListAppointmentByClinicIdAndPeriodRequest request)
    {
        return Ok(_appointmentService.GetListAppointmentByClinicIdAndPeriod(request));
    }
    [HttpPost("list-appointment-by-doctor-id-and-date")]
    public IActionResult GetListAppointmentByDoctorIdAndDate([FromBody]ListAppointmentByDoctorIdAndDateRequest request)
    {
        return Ok(_appointmentService.GetListAppointmentByDoctorIdAndDate(request));
    }
    [HttpPost("list-appointment-by-clinic-id-and-date")]
    public IActionResult GetListAppointmentByClinicIdAndDate([FromBody]ListAppointmentByClinicIdAndDateRequest request)
    {
        return Ok(_appointmentService.GetListAppointmentByClinicIdAndDate(request));
    }

    [HttpGet("list-appointment-completed-by-patient-id/{id}")]
    public IActionResult GetListAppointmentCompletedByPatientId(Guid id)
    {
        return Ok(_appointmentService.GetListAppointmentCompletedByPatientId(id));
    }
    [HttpGet("list-appointment-active-by-patient-id/{id}")]
    public IActionResult GetListAppointmentActiveByPatientId(Guid id)
    {
        return Ok(_appointmentService.GetListAppointmentActiveByPatientId(id));
    }
}