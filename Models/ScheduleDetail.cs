namespace ClinicNetCore.Models;

public class ScheduleDetail
{
    public Guid Id { get; set; }
    public string TimeSlot { get; set; }
    public int Duration { get; set; }
    public int Status { get; set; } // 1 = Active, 0 = Inactive
    public Guid ScheduleId { get; set; }
    
}
