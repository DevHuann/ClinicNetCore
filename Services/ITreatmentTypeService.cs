using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.TreatmentType;
using ClinicNetCore.Models.ResponseModels.TreatmentType;

namespace ClinicNetCore.Services;

public interface ITreatmentTypeService
{
    List<TreatmentType> ListTreatmentTypeByDoctorId(Guid id);
    CreateTreatmentTypeResponse CreateTreatmentType(CreateTreatmentTypeRequest request);
    EditTreatmentTypeResponse EditTreatmentType(EditTreatmentTypeRequest request);
    bool DeleteTreatmentType(Guid id);
}