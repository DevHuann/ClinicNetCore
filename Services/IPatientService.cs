using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;
using ClinicNetCore.Models.ResponseModels.Patient;
using Microsoft.AspNetCore.Identity;

namespace ClinicNetCore.Services;

public interface IPatientService
{
    Task<IdentityResult> PatientRegistration(PatientRegistrationRequest request);
    List<ListPatientResponse> ListPatient();
    PatientResponse ListPatient(ListUserRequest request);
    Patient GetPatientById(Guid id);
    List<ListPatientResponse> ListPatientByDoctorId(Guid id);
    List<ListPatientResponse> ListPatientByClinicId(Guid id);

}