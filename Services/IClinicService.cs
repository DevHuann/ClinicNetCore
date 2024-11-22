using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.RequestModels.Clinic;
using ClinicNetCore.Models.ResponseModels.Clinic;

namespace ClinicNetCore.Services;

public interface IClinicService
{
    Task<bool> ClinicRegistration(ClinicRegistrationRequest request);
    List<ListClinicResponse> GetListClinic();
    ClinicResponse ListClinic(ListUserRequest request);
    EditClinicResponse EditClinic(EditClinicRequest request);
    bool DeleteClinic(Guid id);
    Task<GetListDoctorWithClinicIdResponse> GetListDoctorByClinicId(Guid clinicId);
    
}