using System.ClientModel;
using System.Data;
using Microsoft.AspNetCore;
using Microsoft.
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Test1A.Models.DTOs;

namespace Test1A.Services;
  
public class AppointmentService : IAppointmentService
{
    private readonly SqlConnection conn;
    public async Task<AppointmentDTO> GetAppointment(int appointmentId)
    {
        string database =  "db=localhost(localdb)\\MSSQLLocalDB; database=Test1A; Integrated Security=true";
        
        string query = "@SELECT * FROM dbo.Appointment_Service " +
                       "JOIN dbo.Appointment ON dbo.Appointment_Service.appointment_id = dbo.Appointment.appointment_id" +
                       "Join dbo.Patient ON dbo.Patient.patient_id = dbo.Appointment.patient_id" +
                       "Join dbo.Doctor ON dbo.Doctor.doctor_id = dbo.Appointment.doctor_id" +
                       "WHERE dbo.Appointment.appointment_id = @appointmentId";
        
        using (var conn = new SqlConnection(database))
        using (var cmd = new SqlCommand(query, conn))
        {
            var result = cmd.ExecuteScalar();
            var appointment = new AppointmentDTO()
            {
                AppointmentId = cmd.
            };
            if(result != null)
            cmd.Parameters.Add("@AppointmentId", SqlDbType.Int).Value = appointmentId;
            return result;
        }
    }

    public async Task<AppointmentDTO> AddAppointment(AppointmentDTO appointmentDTO)
    {
        string database =  "db=localhost(localdb)\\MSSQLLocalDB; database=Test1A; Integrated Security=true";
        string query = "@SELECT * FROM dbo.Appointment WHERE appointment_id = @appointmentId";
        
        using (var conn = new SqlConnection(database))
        using (var cmd = new SqlCommand(query, conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            var appointment = new AppointmentDTO()
            {
                AppointmentId = appointmentDTO.AppointmentId,
                Date = appointmentDTO.Date,
                DoctorId = appointmentDTO.DoctorId,
                PatientId = appointmentDTO.PatientId,
            };

            if ("@AppointmentId" == cmd.Parameters["@AppointmentId"].Value) throw new Exception("Appointment already exists");
            if ("@DoctorId" != cmd.Parameters["@DoctorId"].Value) throw new Exception("Doctor already exists");
            if("@PatientId" != cmd.Parameters["@PatientId"].Value) throw new Exception("Patient already exists");

            conn.BeginTransaction();
            
        }
    }
}