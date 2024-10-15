﻿// <auto-generated />
using System;
using ClinicNetCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicNetCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClinicNetCore.Models.Announcement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnnContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AnnTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("ClinicNetCore.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ClinicNetCore.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ClinicNetCore.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AppDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AppTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArriveStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uuid");

                    b.Property<int>("ConsultStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("TreatmentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ClinicNetCore.Models.BusinessHour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uuid");

                    b.Property<string>("CloseSat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CloseSun")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CloseWeek")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OpenSat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OpenSun")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OpenWeek")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("BusinessHours");
                });

            modelBuilder.Entity("ClinicNetCore.Models.ClinicImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uuid");

                    b.Property<string>("ClinicImageFilename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("ClinicImages");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<string>("ScheduleWeek")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ClinicNetCore.Models.ScheduleDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("TimeSlot")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ScheduleDetails");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Speciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("SpecialityIcon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpecialityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("ClinicNetCore.Models.TreatmentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<string>("TreatmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("TreatmentTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ClinicNetCore.Models.Clinic", b =>
                {
                    b.HasBaseType("ClinicNetCore.Models.ApplicationUser");

                    b.Property<string>("ClinicName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClinicStatus")
                        .HasColumnType("integer");

                    b.Property<string>("ClinicUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClinicZipcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Clinic");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Doctor", b =>
                {
                    b.HasBaseType("ClinicNetCore.Models.ApplicationUser");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uuid");

                    b.Property<int>("ConsultFee")
                        .HasColumnType("integer");

                    b.Property<string>("DoctorAvatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoctorDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DoctorDob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DoctorExperience")
                        .HasColumnType("integer");

                    b.Property<string>("DoctorGender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoctorSpeciality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoctorSpokenLanguages")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("ClinicId");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Patient", b =>
                {
                    b.HasBaseType("ClinicNetCore.Models.ApplicationUser");

                    b.Property<int>("PatientAge")
                        .HasColumnType("integer");

                    b.Property<string>("PatientAvatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PatientDob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PatientGender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PatientIdentity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PatientMaritalStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PatientNationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Announcement", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Clinic", null)
                        .WithMany("Announcements")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.Appointment", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Clinic", null)
                        .WithMany("Appointments")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicNetCore.Models.Doctor", null)
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicNetCore.Models.Patient", null)
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.BusinessHour", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Clinic", null)
                        .WithMany("BusinessHours")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.ClinicImage", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Clinic", null)
                        .WithMany("ClinicImages")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.Review", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Doctor", null)
                        .WithMany("Reviews")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicNetCore.Models.Patient", null)
                        .WithMany("Reviews")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.Schedule", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Doctor", null)
                        .WithMany("Schedules")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.ScheduleDetail", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Schedule", null)
                        .WithMany("ScheduleDetails")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.TreatmentType", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Doctor", null)
                        .WithMany("TreatmentTypes")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("ClinicNetCore.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ClinicNetCore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ClinicNetCore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("ClinicNetCore.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicNetCore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ClinicNetCore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.Doctor", b =>
                {
                    b.HasOne("ClinicNetCore.Models.Clinic", null)
                        .WithMany("Doctors")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicNetCore.Models.Schedule", b =>
                {
                    b.Navigation("ScheduleDetails");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Clinic", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("Appointments");

                    b.Navigation("BusinessHours");

                    b.Navigation("ClinicImages");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Reviews");

                    b.Navigation("Schedules");

                    b.Navigation("TreatmentTypes");
                });

            modelBuilder.Entity("ClinicNetCore.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
