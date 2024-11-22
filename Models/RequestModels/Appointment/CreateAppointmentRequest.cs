namespace ClinicNetCore.Models.RequestModels.Appointment;

public class CreateAppointmentRequest
{

    public DateTime AppDate { get; set; }
    public string AppTime { get; set; }
    public string TreatmentType { get; set;}
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid ClinicId { get; set; }
    
}