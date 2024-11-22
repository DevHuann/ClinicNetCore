namespace ClinicNetCore.Models.RequestModels.Appointment;

public class ListAppointmentByClinicIdAndDateRequest
{
    public Guid ClinicId { get; set; }
    public DateTime Date { get;set;}
}