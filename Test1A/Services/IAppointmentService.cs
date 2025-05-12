using Test1A.Models.DTOs;

namespace Test1A.Services;

public interface IAppointmentService
{
    public Task<AppointmentDTO> GetAppointment(int appointmentId);
    public Task<AppointmentDTO> AddAppointment(AppointmentDTO appointment);
}