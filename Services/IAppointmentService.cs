using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.Appointment;
using ClinicNetCore.Models.ResponseModels.Appointment;

namespace ClinicNetCore.Services;

public interface IAppointmentService
{
    CreateAppointmentResponse CreateAppointment(CreateAppointmentRequest request);
    CreateAppointmentResponse DoctorCreateAppointment(CreateAppointmentRequest request);
    bool ConfirmConsultStatus(Guid id);
    bool ConfirmArriveStatus(Guid id);
    bool ConfirmStatus(Guid id);
    bool DeleteAppointment(Guid id);
    List<Appointment> GetListAppointmentByPatientId(Guid id);
    List<Appointment> GetListAppointmentsByDoctorIdAndDateAndNotyetConfirmed(Guid id,DateTime date);
    List<Appointment> GetListAppointmentsByClinicIdAndDateAndNotyetConfirmed(Guid id,DateTime date);

    List<Appointment> GetListAppointmentByDoctorIdAndPeriod(ListAppointmentByDoctorIdAndPeriodRequest request);
    List<Appointment> GetListAppointmentByClinicIdAndPeriod(ListAppointmentByClinicIdAndPeriodRequest request);
    List<Appointment> GetListAppointmentByClinicIdAndDate(ListAppointmentByClinicIdAndDateRequest request);
    List<Appointment> GetListAppointmentByDoctorIdAndDate(ListAppointmentByDoctorIdAndDateRequest request);
    List<Appointment> GetListAppointmentCompletedByPatientId(Guid id);
    List<Appointment> GetListAppointmentActiveByPatientId(Guid id);

}