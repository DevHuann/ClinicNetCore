using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;

namespace ClinicNetCore.Services;

public interface IUserService
{
    Task<LoginResponse> Login(LoginRequest request);
    Task<bool> Registration(RegistrationRequest request);
    // List<ListUserResponse> GetListUser();
    // bool DeleteUser(Guid userId);
    // Task<EditUserResponse> EditUser(EditUserRequest request);
    // Task<GetUserById> GetUserById(Guid userId);
    // UserResponse ListUser(ListUserRequest request);
}