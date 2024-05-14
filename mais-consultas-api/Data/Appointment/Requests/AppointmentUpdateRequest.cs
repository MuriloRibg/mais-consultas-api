namespace mais_consultas_api.Data.Appointment.Requests
{
    public class AppointmentUpdateRequest
    {
        public DateTime DateTime { get; set; }
        public int ProfessionalId { get; set; }
        public int ProviderId { get; set; }
        public int PatientId { get; set; }
    }
}
