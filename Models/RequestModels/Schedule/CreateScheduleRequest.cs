namespace ClinicNetCore.Models.RequestModels.Schedule;

public class CreateScheduleRequest
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string ScheduleWeek { get; set; }
    public Guid DoctorId { get; set; }
}