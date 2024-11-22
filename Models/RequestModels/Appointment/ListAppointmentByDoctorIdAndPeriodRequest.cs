namespace ClinicNetCore.Models.RequestModels.Appointment;

public class ListAppointmentByDoctorIdAndPeriodRequest
{
    public Guid doctorId { get; set; }
    public DateTime fromDate { get; set; }
    public DateTime toDate { get; set; }
}