namespace ClinicNetCore.Models;

public class Review
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }
    public DateTime Date { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }
    
}
