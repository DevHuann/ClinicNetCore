namespace ClinicNetCore.Models.ResponseModels.Schedule;

public class EditScheduleDetailResponse
{
    public Guid Id { get; set; }
    public string TimeSlot { get; set; }
    public int Duration { get; set; }
    public Guid ScheduleId { get; set; }
}