using ClinicNetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicNetCore.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public DbSet<ApplicationRole> AspNetRoles { get; set; }
    public DbSet<ApplicationUser> AspNetUsers { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    
    public DbSet<Appointment> Appointments { get; set; }
    
    public DbSet<Clinic> Clinics { get; set; }
    
    public DbSet<ClinicImage> ClinicImages { get; set; }
    
    public DbSet<Doctor> Doctors { get; set; }
    
    public DbSet<Patient> Patients { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Schedule> Schedules { get; set; }
    
    public DbSet<ScheduleDetail> ScheduleDetails { get; set; }
    
    public DbSet<Speciality> Specialities { get; set; }
    
    public DbSet<TreatmentType> TreatmentTypes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Review) // Một Appointment có một Rating
            .WithOne(r => r.Appointment) // Một Rating thuộc về một Appointment
            .HasForeignKey<Review>(r => r.AppointmentId); // AppointmentId là foreign key
    }
}