namespace ClinicNetCore.Models.ResponseModels.TreatmentType;

public class CreateTreatmentTypeResponse
{   
    public string TreatmentName { get; set; }
    public Guid DoctorId { get; set; }
}