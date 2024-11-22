namespace ClinicNetCore.Models;

public class TreatmentType
{
    public Guid Id { get; set; }
    public string TreatmentName { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    
}
