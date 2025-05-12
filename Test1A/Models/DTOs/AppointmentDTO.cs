namespace Test1A.Models.DTOs;

public class AppointmentDTO
{
    public int PatientId { get; set; }
    public int AppointmentId { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
}