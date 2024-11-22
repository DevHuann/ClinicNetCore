namespace ClinicNetCore.Models.ResponseModels.Schedule;

public class CreateScheduleResponse
{
    public Guid Id { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string ScheduleWeek { get; set; }
    public Guid DoctorId { get; set; }
}