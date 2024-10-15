namespace ClinicNetCore.Models;

public class Patient:ApplicationUser
{
    public string PatientAvatar { get; set; }
    public string PatientIdentity { get; set; }
    public string PatientNationality { get; set; }
    public string PatientGender { get; set; }
    public string PatientMaritalStatus { get; set; }
    public DateTime PatientDob { get; set; }
    public int PatientAge { get; set; }
    
    public List<Appointment> Appointments { get; set; }
    public List<Review>Reviews { get; set; }
    
}
