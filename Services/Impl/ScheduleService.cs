using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.Schedule;
using ClinicNetCore.Models.ResponseModels.Schedule;
using ClinicNetCore.Models.ResponseModels.TreatmentType;

namespace ClinicNetCore.Services.Impl;

public class ScheduleService:IScheduleService
{
    private readonly ApplicationDbContext _context;

    public ScheduleService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    public CreateScheduleResponse CreateSchedule(CreateScheduleRequest request)
    {
        var schedule = new Schedule
        {
            DateFrom = request.DateFrom,
            DateTo = request.DateTo,
            ScheduleWeek = request.ScheduleWeek,
            DoctorId = request.DoctorId,
        };
        _context.Schedules.Add(schedule);
        _context.SaveChanges();
        return new CreateScheduleResponse
        {
            Id = schedule.Id,
            DateFrom = schedule.DateFrom,
            DateTo = schedule.DateTo,
            ScheduleWeek = schedule.ScheduleWeek,
            DoctorId = schedule.DoctorId,
        };
    }

    public EditScheduleResponse EditSchedule(EditScheduleRequest request)
    {
        var schedule = _context.Schedules.FirstOrDefault(s => s.Id == request.Id);
        if (schedule == null)
        {
            throw new Exception("Schedule not found!");
        }

        schedule.DateFrom = request.DateFrom;
        schedule.DateTo = request.DateTo;
        schedule.ScheduleWeek = request.ScheduleWeek;
        _context.SaveChanges();
        return new EditScheduleResponse
        {
            Id = schedule.Id,
            DateFrom = schedule.DateFrom,
            DateTo = schedule.DateTo,
            ScheduleWeek = schedule.ScheduleWeek,
        };
    }

    public List<Schedule> ListScheduleByDoctorId(Guid id)
    {
        var schedules = _context.Schedules.Where(s => s.DoctorId == id).ToList();
        if (schedules ==null)
        {
            throw new Exception("Schedule not found!");
        }
        return schedules;
    }

    public CreateScheduleDetailResponse CreateScheduleDetail(CreateScheduleDetailRequest request)
    {
        var schedule = _context.Schedules.FirstOrDefault(s => s.Id == request.ScheduleId);
        if (schedule == null)
        {
            throw new Exception("Schedule not found!");
        }

        var scheduleDetail = new ScheduleDetail
        {
            ScheduleId = request.ScheduleId,
            TimeSlot = request.TimeSlot,
            Duration = request.Duration
        };
        _context.ScheduleDetails.Add(scheduleDetail);
        _context.SaveChanges();
        return new CreateScheduleDetailResponse
        {
            ScheduleId = scheduleDetail.ScheduleId,
            TimeSlot = scheduleDetail.TimeSlot,
            Duration = scheduleDetail.Duration
        };
    }

    public EditScheduleDetailResponse EditScheduleDetail(EditScheduleDetailRequest request)
    {
        var scheduleDetail = _context.ScheduleDetails.FirstOrDefault(s => s.Id == request.Id);
        if (scheduleDetail == null)
        {
            throw new Exception("ScheduleDetail not found!");
        }

        scheduleDetail.TimeSlot = request.TimeSlot;
        scheduleDetail.Duration = request.Duration;
        _context.SaveChanges();
        return new EditScheduleDetailResponse
        {
            Id = scheduleDetail.Id,
            ScheduleId = scheduleDetail.ScheduleId,
            TimeSlot = scheduleDetail.TimeSlot,
            Duration = scheduleDetail.Duration
        };
    }

    public List<ScheduleDetail> ListScheduleDetailByScheduleId(Guid id)
    {
        var scheduleDetails = _context.ScheduleDetails.Where(s => s.ScheduleId == id).ToList();
        if (scheduleDetails == null)
        {
            throw new Exception("ScheduleDetail not found!");
        }

        return scheduleDetails;
    }
}