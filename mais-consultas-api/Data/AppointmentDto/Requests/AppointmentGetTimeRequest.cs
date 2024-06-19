namespace mais_consultas_api.Data.AppointmentDto.Requests
{
    public class AppointmentGetTimeRequest
    {
        public long IdProvider { get; set; }
        public long IdService { get; set; }
        public long? IdProfessional { get; set; }
        public DateTime DataConsulta { get; set; }
    }
}