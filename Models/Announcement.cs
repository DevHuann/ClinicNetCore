namespace ClinicNetCore.Models;

public class Announcement
{
    public Guid Id { get; set; }
    public string AnnTitle { get; set; }
    public string AnnContent { get; set; }
    public DateTime DateCreated { get; set; }
    public Guid ClinicId { get; set; }
    public Clinic Clinic { get; set; }
}