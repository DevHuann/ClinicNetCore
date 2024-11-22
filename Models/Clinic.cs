namespace ClinicNetCore.Models;

public class Clinic : ApplicationUser
{
    public string ClinicName { get; set; }
    
    public string ClinicUrl { get; set; }
    
    public string ClinicZipcode { get; set; }
    public string OpenWeek { get; set; }
    public string CloseWeek { get; set; }
    public string OpenSat { get; set; }
    public string CloseSat { get; set; }
    public string OpenSun { get; set; }
    public string CloseSun { get; set; }
    public int ClinicStatus { get; set; }
    
    public List<ClinicImage>? ClinicImages { get; set; }
    
    public List<Announcement>? Announcements { get; set; }
    
    public List<Appointment>? Appointments { get; set; }
    
    public List<MedicalRecord>? MedicalRecords { get; set; }
    public List<Doctor>? Doctors { get; set; }

  

  
}
