using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;

namespace ClinicNetCore.Services;

public interface IDoctorService
{
    Task<bool> DoctorRegistration(DoctorRegistrationRequest request);
    List<ListDoctorResponse> ListDoctor();
}