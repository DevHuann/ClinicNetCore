namespace ClinicNetCore.Models;

public class Clinic : ApplicationUser
{
    public string ClinicName { get; set; }
    
    public string ClinicUrl { get; set; }
    
    public string ClinicZipcode { get; set; }
    
    public int ClinicStatus { get; set; }
    
    public List<ClinicImage> ClinicImages { get; set; }
    
    public List<Announcement> Announcements { get; set; }
    
    public List<Appointment> Appointments { get; set; }
    
    public List<BusinessHour>BusinessHours { get; set; }
    
    public List<Doctor>Doctors { get; set; }

  

  
}
