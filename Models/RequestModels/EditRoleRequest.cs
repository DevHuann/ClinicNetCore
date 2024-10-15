namespace ClinicNetCore.Models.RequestModels
{
    public class EditRoleRequest
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
    }
}