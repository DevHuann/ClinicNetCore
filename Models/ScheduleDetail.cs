namespace ClinicNetCore.Models;

public class ScheduleDetail
{
    public Guid Id { get; set; }
    public string TimeSlot { get; set; }
    public int Duration { get; set; }
    public Guid ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
}
