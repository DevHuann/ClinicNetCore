using Microsoft.AspNetCore.Identity;

namespace ClinicNetCore.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public DateTime DateCreated { get; set; }
    }
}