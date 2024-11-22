namespace ClinicNetCore.Models.RequestModels.Appointment;

public class ListAppointmentByClinicIdAndPeriodRequest
{
    public Guid clinicId { get; set; }
    public DateTime fromDate { get; set; }
    public DateTime toDate { get; set; }
}