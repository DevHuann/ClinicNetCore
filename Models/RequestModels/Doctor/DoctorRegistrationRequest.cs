namespace ClinicNetCore.Models.RequestModels;

public class DoctorRegistrationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string FullName { get; set; }
    public string DoctorAvatar { get; set; }
    public string DoctorSpeciality { get; set; }
    public int DoctorExperience { get; set; }
    public string DoctorDescription { get; set; }
    public string DoctorSpokenLanguages { get; set; }
    public string DoctorGender { get; set; }
    public DateTime DoctorDob { get; set; }
    public int ConsultFee { get; set; }
    public Guid ClinicId { get; set; }
}