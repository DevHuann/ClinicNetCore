namespace ClinicNetCore.Models.RequestModels;

public class ClinicRegistrationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string FullName { get; set; }
    public string ClinicName { get; set; }
    public string ClinicUrl { get; set; }
    public string ClinicZipcode { get; set; }
    
}