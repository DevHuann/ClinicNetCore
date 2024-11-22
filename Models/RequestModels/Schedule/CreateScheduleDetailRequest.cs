namespace ClinicNetCore.Models.RequestModels.Schedule;

public class CreateScheduleDetailRequest
{
    
    public string TimeSlot { get; set; }
    public int Duration { get; set; }
    public Guid ScheduleId { get; set; }
}