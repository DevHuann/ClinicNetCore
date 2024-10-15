using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;

namespace ClinicNetCore.Services;

public interface IClinicService
{
    Task<bool> ClinicRegistration(ClinicRegistrationRequest request);

    List<ListClinicResponse> ListClinic();
}