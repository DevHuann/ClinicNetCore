using CKLS.Identity.Models;
using ClinicNetCore.Settings;

namespace ClinicNetCore.Settings
{
    public static class SystemClaim
    {
        public static List<ClaimInfo> claims = new List<ClaimInfo>()
        {
            UIClaims.Per,
            UIClaims.CourseClaims, 
            UIClaims.CombinedCourseClaims,
            UIClaims.UserManagement,
           
        };
        
    }

   
}