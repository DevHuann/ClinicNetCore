namespace ClinicNetCore.Models.ResponseModels;

public class ClinicRegistrationResponse
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string FullName { get; set; }
    public string ClinicName { get; set; }
    public string ClinicUrl { get; set; }
    public string ClinicZipcode { get; set; }
    public DateTime DateCreated { get; set; }
    public List<string> Roles { get; set; }
}