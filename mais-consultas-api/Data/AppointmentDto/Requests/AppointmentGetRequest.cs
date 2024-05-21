namespace mais_consultas_api.Data.AppointmentDto.Requests
{
    public class AppointmentGetRequest
    {
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? ProfessionalId { get; set; }
        public int? ProviderId { get; set; }
    }
}
