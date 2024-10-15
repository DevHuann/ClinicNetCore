namespace ClinicNetCore.Models;

public class Doctor:ApplicationUser
{
    public string DoctorAvatar { get; set; }
    public string DoctorSpeciality { get; set; }
    public int DoctorExperience { get; set; }
    public string DoctorDescription { get; set; }
    public string DoctorSpokenLanguages { get; set; }
    public string DoctorGender { get; set; }
    public DateTime DoctorDob { get; set; }
    public int ConsultFee { get; set; }
    public Guid ClinicId { get; set; }
    public List<Appointment> Appointments { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Schedule> Schedules { get; set; }
    public List<TreatmentType> TreatmentTypes { get; set; }
    
}
