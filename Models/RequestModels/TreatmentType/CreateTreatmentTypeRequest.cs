namespace ClinicNetCore.Models.RequestModels.TreatmentType;

public class CreateTreatmentTypeRequest
{
    public string TreatmentName { get; set; }
    public Guid DoctorId { get; set; }
}