namespace ClinicNetCore.Models.ResponseModels;

public class PatientRegistrationResponse
{
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PatientAvatar { get; set; }
    public string PatientIdentity { get; set; }
    public string PatientNationality { get; set; }
    public string PatientGender { get; set; }
    public string PatientMaritalStatus { get; set; }
    public DateTime PatientDob { get; set; }
    public int PatientAge { get; set; }
    public DateTime DateCreated { get; set; }

}