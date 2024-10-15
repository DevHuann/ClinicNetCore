using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;

namespace ClinicNetCore.Services;

public interface IPatientService
{
    Task<bool> PatientRegistration(PatientRegistrationRequest request);
    List<ListPatientResponse> ListPatient();
}