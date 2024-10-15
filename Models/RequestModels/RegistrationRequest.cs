namespace ClinicNetCore.Models.RequestModels
{
    public class RegistrationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        
        public string Address { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}