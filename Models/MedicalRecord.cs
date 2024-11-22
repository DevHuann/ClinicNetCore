namespace ClinicNetCore.Models;

public class MedicalRecord
{
    public Guid Id { get; set; }
    public string Sympton { get; set; }
    public string Diagnosis { get; set; }
    public DateTime DateRecorded { get; set; }
    public string Advice { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid ClinicId { get; set; }
    public Clinic Clinic { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    
}