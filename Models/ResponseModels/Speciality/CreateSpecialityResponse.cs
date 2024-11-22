namespace ClinicNetCore.Models.ResponseModels.Speciality;

public class CreateSpecialityResponse
{
    public Guid Id { get; set; }
    public string SpecialityName { get; set; }
    public string SpecialityIcon { get; set; }
}