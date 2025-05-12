
using Microsoft.AspNetCore.Mvc;
using Test1A.Models.DTOs;
using Test1A.Services;

namespace Test1A.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentService _appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        
        [HttpGet ("/api/appointments/{appointmentId}")]
        public async Task<IActionResult> GetAppointment(int appointmentId)
        {
            var data = _appointmentService.GetAppointment(appointmentId);

            if (data.IsCompleted)
            {
                return Ok(data);
            }
            else if(data.)
        }
        
        [HttpPost]
        public async Task<IActionResult> AddAppointment()
        {
            var appointment = _appointmentService.AddAppointment(new AppointmentDTO());

            if (appointment.IsCompleted) return Ok();
            if (appointment.IsCanceled)
            {
                if (appointment.Result != null) 
            }
        }
    }
}