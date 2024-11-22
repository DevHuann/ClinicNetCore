namespace ClinicNetCore.Models.RequestModels.TreatmentType;

public class EditTreatmentTypeRequest
{
    public Guid Id { get; set; }
    public string TreatmentName { get; set; }
    public Guid DoctorId { get; set; }
}