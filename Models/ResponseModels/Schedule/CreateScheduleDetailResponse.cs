namespace ClinicNetCore.Models.ResponseModels.Schedule;

public class CreateScheduleDetailResponse
{
    public Guid Id { get; set; }
    public string TimeSlot { get; set; }
    public int Duration { get; set; }
    public Guid ScheduleId { get; set; }
}