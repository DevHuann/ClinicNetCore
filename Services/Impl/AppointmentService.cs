using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.Appointment;
using ClinicNetCore.Models.ResponseModels.Appointment;
using Microsoft.EntityFrameworkCore;

namespace ClinicNetCore.Services.Impl;

public class AppointmentService:IAppointmentService
{
    private readonly ApplicationDbContext _context;

    public AppointmentService(ApplicationDbContext context)
    {
        _context = context;
    }
    public CreateAppointmentResponse CreateAppointment(CreateAppointmentRequest request)
    {
        var appointment = new Appointment
        {
            AppDate = request.AppDate,
            AppTime = request.AppTime,
            TreatmentType = request.TreatmentType,
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            ClinicId = request.ClinicId,
            Status = 0,
            ConsultStatus = 0,
            ArriveStatus = 0,
        };
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
        return new CreateAppointmentResponse
        {
            Id = appointment.Id,
            AppDate = appointment.AppDate,
            AppTime = appointment.AppTime,
            TreatmentType = appointment.TreatmentType,
            PatientId = appointment.PatientId,
            DoctorId = appointment.DoctorId,
            ClinicId = appointment.ClinicId,
            Status = appointment.Status,
            ConsultStatus = appointment.ConsultStatus,
            ArriveStatus = appointment.ArriveStatus
        };
    }

    public CreateAppointmentResponse DoctorCreateAppointment(CreateAppointmentRequest request)
    {
        var appointment = new Appointment
        {
            AppDate = request.AppDate,
            AppTime = request.AppTime,
            TreatmentType = request.TreatmentType,
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            ClinicId = request.ClinicId,
            Status = 0,
            ConsultStatus = 1,
            ArriveStatus = 0,
            IsReviewed = false
        };
        if (appointment.AppDate < DateTime.UtcNow)
        {
            throw new Exception("Invalid Date!!");
        }
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
        return new CreateAppointmentResponse
        {
            Id = appointment.Id,
            AppDate = appointment.AppDate,
            AppTime = appointment.AppTime,
            TreatmentType = appointment.TreatmentType,
            PatientId = appointment.PatientId,
            DoctorId = appointment.DoctorId,
            ClinicId = appointment.ClinicId,
            Status = appointment.Status,
            ConsultStatus = appointment.ConsultStatus,
            ArriveStatus = appointment.ArriveStatus,
        };
    }

    public bool ConfirmConsultStatus(Guid id)
    {
        var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null)
        {
            throw new Exception("Appointment not found!");
        }
        appointment.ConsultStatus = 1;
        _context.SaveChanges();
        return true;
    }

    public bool ConfirmArriveStatus(Guid id)
    {
        var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id );
        if (appointment == null)
        {
            throw new Exception("Appointment not found!");
        }
        appointment.ArriveStatus = 1;
        _context.SaveChanges();
        return true;
    }

    public bool ConfirmStatus(Guid id)
    {
        var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null)
        {
            throw new Exception("Appointment not found!");
        }
        appointment.Status = 1;
        _context.SaveChanges();
        return true;
    }

    public bool DeleteAppointment(Guid id)
    {
        var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null)
        {
            throw new Exception("Appointment not found!");
        }
        _context.Remove(appointment);
        _context.SaveChanges();
        return true;
    }

    public List<Appointment> GetListAppointmentByPatientId(Guid id)
    {
        var appointments = _context.Appointments.Where(a => a.PatientId == id).ToList();
        if (appointments == null)
        {
            throw new Exception("Appointment not found!");
        }

        return appointments;
    }

    

    public List<Appointment> GetListAppointmentsByDoctorIdAndDateAndNotyetConfirmed(Guid id,DateTime date)
    {

        var appointments = _context.Appointments
            .Include(a => a.Patient)
            .Where(a => a.DoctorId == id && a.AppDate.Date == date.Date && a.Status == 0).ToList();

        return appointments;
    }

    public List<Appointment> GetListAppointmentsByClinicIdAndDateAndNotyetConfirmed(Guid id, DateTime date)
    {
        var appointments = _context.Appointments
            .Include(a => a.Patient)
            .Where(a => a.ClinicId == id && a.AppDate.Date == date.Date && a.Status == 0).ToList();

        return appointments;
    }

    public List<Appointment> GetListAppointmentByDoctorIdAndPeriod(ListAppointmentByDoctorIdAndPeriodRequest request)
    {
        var appointments = _context.Appointments.Where(a => a.DoctorId == request.doctorId && a.AppDate >= request.fromDate &&
                                                            a.AppDate <= request.toDate).ToList();
        if (appointments == null)
        {
            throw new Exception("null");
        }
        

        return appointments;
    }

    public List<Appointment> GetListAppointmentByClinicIdAndPeriod(ListAppointmentByClinicIdAndPeriodRequest request)
    {
        var appointments = _context.Appointments.Where(a => a.ClinicId == request.clinicId && a.AppDate >= request.fromDate &&
                                                            a.AppDate <= request.toDate).ToList();
        if (appointments == null)
        {
            throw new Exception("null");
        }
        return appointments;
    }

    public List<Appointment> GetListAppointmentByClinicIdAndDate(ListAppointmentByClinicIdAndDateRequest request)
    {
        var appointments =
            _context.Appointments.Where(a => a.AppDate.AddHours(7).Date == request.Date.Date && a.ClinicId == request.ClinicId).ToList();
        if (appointments == null)
        {
            throw new Exception("null");
        }

        return appointments;
    }

    public List<Appointment> GetListAppointmentByDoctorIdAndDate(ListAppointmentByDoctorIdAndDateRequest request)
    {
        var appointments =
            _context.Appointments.Where(a => a.AppDate.AddHours(7).Date == request.Date.Date && a.DoctorId == request.DoctorId).ToList();
        if (appointments == null)
        {
            throw new Exception("null");
        }

        return appointments;
    }

    public List<Appointment> GetListAppointmentCompletedByPatientId(Guid id)
    {
        var appointments = _context.Appointments
            .Include(a=>a.Doctor)
            .Include(a=>a.Clinic)
            .Include(a=>a.Review)
            .Where(a => a.PatientId == id && a.Status == 1)
            .OrderByDescending(a => a.AppDate)
            .ToList();
        if (appointments== null)
        {
            throw new Exception("null");
        }

        return appointments;
    }

    public List<Appointment> GetListAppointmentActiveByPatientId(Guid id)
    {
        var appointments = _context.Appointments
            .Include(a=>a.Doctor)
            .Include(a=>a.Clinic)
            .Include(a=>a.Review)
            .Where(a => a.PatientId == id && a.Status == 0)
            .OrderByDescending(a => a.AppDate)
            .ToList();
        if (appointments== null)
        {
            throw new Exception("null");
        }

        return appointments;
    }
}