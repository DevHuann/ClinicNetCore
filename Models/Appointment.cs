namespace ClinicNetCore.Models;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime AppDate { get; set; }
    public string AppTime { get; set; }
    public string TreatmentType { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid ClinicId { get; set; }
    public Clinic Clinic { get; set; }
    public int Status { get; set; } // 1: Confirm, 0: Not Confirm
    public int ConsultStatus { get; set; } // 1: Visited, 0: None
    public int ArriveStatus { get; set; } // 1: Arrived, 0: None
    public Guid? ReviewId { get; set; }
    public Review? Review { get; set; }
    public bool IsReviewed { get; set; }
}
