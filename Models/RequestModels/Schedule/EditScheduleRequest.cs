namespace ClinicNetCore.Models.RequestModels.Schedule;

public class EditScheduleRequest
{
    public Guid Id { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string ScheduleWeek { get; set; }
}