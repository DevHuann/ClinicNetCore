using System.Collections.Generic;
using CKLS.Identity.Models;

namespace ClinicNetCore.Settings
{
    public class UIClaims
    {
        public const string CourseRead = "Course.Read";
        public const string CourseWrite = "Course.Write";
        public const string CombinedCourseRead = "CombinedCourse.Read";
        public const string CombinedCourseWrite = "CombinedCourse.Write";
        public const string Admin = "Admin";
        public const string Clinic = "Clinic";
        public const string Doctor = "Doctor";
        public const string Patient = "Patient";
        public const string UserRead = "User.Read";
        public const string UserWrite = "User.Write";


        public static ClaimInfo CourseClaims = new ClaimInfo("Quản lý thông tin khoá học", "CourseManagementClaim",
            new List<Permission>()
            {
                new Permission("Đọc", CourseRead, 1),
                new Permission("Ghi", CourseWrite, 2)
            });

        public static ClaimInfo CombinedCourseClaims = new ClaimInfo("Quản lý thông tin lột trình học",
            "CombinedCourseManagementClaim", new List<Permission>()
            {
                new Permission("Đọc", CombinedCourseRead, 1),
                new Permission("Ghi", CombinedCourseWrite, 2)
            });

        public static ClaimInfo Per = new ClaimInfo("Quyền truy cập", "Per", new List<Permission>()
        {
            new Permission("Admin", Admin, 1),
            new Permission("Clinic", Clinic, 2),
            new Permission("Doctor", Doctor, 3),
            new Permission("Patient", Patient, 4)

        });

        public static ClaimInfo UserManagement = new ClaimInfo("Quản lí người dùng", "Usermanagement",
            new List<Permission>()
            {
                new Permission("Đọc", UserRead, 1),
                new Permission("Ghi", UserWrite, 2)
            });
    }
}