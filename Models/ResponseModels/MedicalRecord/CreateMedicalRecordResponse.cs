namespace ClinicNetCore.Models.ResponseModels.MedicalRecord;

public class CreateMedicalRecordResponse
{
    public Guid Id { get; set; }
    public string Sympton { get; set; }
    public string Diagnosis { get; set; }
    public DateTime DateRecorded { get; set; }
    public string Advice { get; set; }
    public Guid PatientId { get; set; }
    public Guid ClinicId { get; set; }
    public Guid DoctorId { get; set; }
}