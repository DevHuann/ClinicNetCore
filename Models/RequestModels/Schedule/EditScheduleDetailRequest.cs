namespace ClinicNetCore.Models.RequestModels.Schedule;

public class EditScheduleDetailRequest
{
    public Guid Id { get; set; }
    public string TimeSlot { get; set; }
    public int Duration { get; set; }
    public Guid ScheduleId { get; set; }
}