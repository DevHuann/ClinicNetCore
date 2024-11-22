namespace ClinicNetCore.Models.RequestModels.Clinic;

public class EditClinicRequest
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string FullName { get; set; }

    public string ClinicName { get; set; }
    public string ClinicUrl { get; set; }
    public string OpenWeek { get; set; }
    public string CloseWeek { get; set; }
    public string OpenSat { get; set; }
    public string CloseSat { get; set; }
    public string OpenSun { get; set; }
    public string CloseSun { get; set; }
}