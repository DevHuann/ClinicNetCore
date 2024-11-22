namespace ClinicNetCore.Models.RequestModels.Appointment;

public class ListAppointmentByDoctorIdAndDateRequest
{
    public Guid DoctorId { get; set; }
    public DateTime Date { get;set;}
}