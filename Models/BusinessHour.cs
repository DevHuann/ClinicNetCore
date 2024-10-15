namespace ClinicNetCore.Models;

public class BusinessHour
{
    public Guid Id { get; set; }
    public string OpenWeek { get; set; }
    public string CloseWeek { get; set; }
    public string OpenSat { get; set; }
    public string CloseSat { get; set; }
    public string OpenSun { get; set; }
    public string CloseSun { get; set; }
    public Guid ClinicId { get; set; }
    
}
