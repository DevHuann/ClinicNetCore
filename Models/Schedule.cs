namespace ClinicNetCore.Models;

public class Schedule
{
    public Guid Id { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string ScheduleWeek { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public List<ScheduleDetail> ScheduleDetails { get; set; }

    
}
