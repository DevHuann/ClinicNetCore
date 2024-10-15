using System;

namespace ClinicNetCore.Models.RequestModels
{
    public class FindClaimByRoleIdRequest
    {
        public Guid RoleId { get; set; }
    }
}