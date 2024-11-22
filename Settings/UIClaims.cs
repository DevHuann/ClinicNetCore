using CKLS.Identity.Models;

namespace ClinicNetCore.Settings
{
    public class UIClaims
    {
        public const string Admin = "Admin";
        public const string Clinic = "Clinic";
        public const string Doctor = "Doctor";
        public const string Patient = "Patient";
        public const string ClinicRead = "Clinic.Read";
        public const string ClinicWrite = "Clinic.Write";
        public const string DoctorRead = "Doctor.Read";
        public const string DoctorWrite = "Doctor.Write";
        public const string PatientRead = "Patient.Read";
        public const string PatientWrite = "Patient.Write";
        

        public static ClaimInfo ClinicClaims = new ClaimInfo("Quản lý thông tin phòng khám",
            "ClinicManagementClaim",
            new List<Permission>()
            {
                new Permission("Đọc", ClinicRead, 1),
                new Permission("Ghi", ClinicWrite, 2)
            });

        public static ClaimInfo DoctorClaims = new ClaimInfo("Quản lý thông tin bác sĩ",
            "DoctorManagementClaim", new List<Permission>()
            {
                new Permission("Đọc", DoctorRead, 1),
                new Permission("Ghi", DoctorWrite, 2)
            });
        
        public static ClaimInfo PatientClaims = new ClaimInfo("Quản lý thông tin bệnh nhân",
            "PatientManagementClaim", new List<Permission>()
            {
                new Permission("Đọc", PatientRead, 1),
                new Permission("Ghi", PatientWrite, 2)
            });

        public static ClaimInfo Per = new ClaimInfo("Quyền truy cập", "Per", new List<Permission>()
        {
            new Permission("Admin", Admin, 1),
            new Permission("Clinic", Clinic, 2),
            new Permission("Doctor", Doctor, 3),
            new Permission("Patient", Patient, 4)

        });
        
    }
}