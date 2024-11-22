using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.Schedule;
using ClinicNetCore.Models.ResponseModels.Schedule;
using ClinicNetCore.Models.ResponseModels.TreatmentType;

namespace ClinicNetCore.Services;

public interface IScheduleService
{
    CreateScheduleResponse CreateSchedule(CreateScheduleRequest request);
    EditScheduleResponse EditSchedule(EditScheduleRequest request);
    List<Schedule> ListScheduleByDoctorId(Guid id);
    CreateScheduleDetailResponse CreateScheduleDetail(CreateScheduleDetailRequest request);
    EditScheduleDetailResponse EditScheduleDetail(EditScheduleDetailRequest request);
    List<ScheduleDetail> ListScheduleDetailByScheduleId(Guid id);
}