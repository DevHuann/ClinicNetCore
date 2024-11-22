namespace ClinicNetCore.Models.RequestModels.Speciality;

public class EditSpecialityRequest
{
    public Guid Id { get; set; }
    public string SpecialityName { get; set; }
    public string SpecialityIcon { get; set; }
}