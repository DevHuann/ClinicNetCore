namespace ClinicNetCore.Models.ResponseModels.Clinic;

public class ClinicRegistrationResponse
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string FullName { get; set; }
    public string ClinicName { get; set; }
    public string ClinicUrl { get; set; }
    public string ClinicZipcode { get; set; }
    public string OpenWeek { get; set; }
    public string CloseWeek { get; set; }
    public string OpenSat { get; set; }
    public string CloseSat { get; set; }
    public string OpenSun { get; set; }
    public string CloseSun { get; set; }
    public DateTime DateCreated { get; set; }
    public List<string> Roles { get; set; }
}