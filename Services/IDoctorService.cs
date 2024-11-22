using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.RequestModels.TreatmentType;
using ClinicNetCore.Models.ResponseModels;
using ClinicNetCore.Models.ResponseModels.Doctor;
using ClinicNetCore.Models.ResponseModels.TreatmentType;

namespace ClinicNetCore.Services;

public interface IDoctorService
{
    Task<bool> DoctorRegistration(DoctorRegistrationRequest request);
    List<ListDoctorResponse> ListDoctor();
    DoctorResponse ListDoctor(ListUserRequest request);
    EditDoctorResponse EditDoctor(EditDoctorRequest request);
    List<Doctor> ListDoctorByClinicId(Guid clinicId);
    Doctor GetDoctorById(Guid id);
    bool DeleteDoctor(Guid id);


}