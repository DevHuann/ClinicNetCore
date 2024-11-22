using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.Speciality;
using ClinicNetCore.Models.ResponseModels.Speciality;

namespace ClinicNetCore.Services;

public interface ISpecialityService
{
    List<Speciality> GetListSpeciality();
    CreateSpecialityResponse CreateSpeciality(CreateSpecialityRequest request);
    EditSpecialityResponse EditSpeciality(EditSpecialityRequest request);
    bool DeleteSpeciality(Guid id);
}