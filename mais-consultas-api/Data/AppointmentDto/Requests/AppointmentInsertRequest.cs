namespace mais_consultas_api.Data.AppointmentDto.Requests
{
    public class AppointmentInsertRequest
    {
        public int IdService { get; set; }
        public int IdProvider { get; set; }
        public int IdPatient { get; set; }
        public DateTime DateTime { get; set; }
    }
}
