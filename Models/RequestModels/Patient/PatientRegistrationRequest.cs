namespace ClinicNetCore.Models.RequestModels;

public class PatientRegistrationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string FullName { get; set; }
    public string PatientAvatar { get; set; }
    public string PatientIdentity { get; set; }
    public string PatientNationality { get; set; }
    public string PatientGender { get; set; }
    public string PatientMaritalStatus { get; set; }
    public DateTime PatientDob { get; set; }
}