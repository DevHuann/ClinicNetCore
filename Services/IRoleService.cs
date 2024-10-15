using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;

namespace ClinicNetCore.Services
{
    public interface IRoleService
    {
        List<RoleResponse> GetAllRole();
        Task<RoleResponse> Create(RoleRequest request);
        Task<RespondAPI<string>> UpdateRoleAdminWithUIPermission(Guid Id, RequestUpdateRoleUI model);
        Task<RoleResponse> EditRole(EditRoleRequest request);
        Task<bool> DeleteRole(Guid id);

        Task<FindClaimByRoleIdResponse> FindClaimByRoleId(FindClaimByRoleIdRequest request);
    }
}