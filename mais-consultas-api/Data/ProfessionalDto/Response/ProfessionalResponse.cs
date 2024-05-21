using mais_consultas_api.Data.AppointmentDto.Responses;
using mais_consultas_api.Data.ProviderDto.Responses;
using mais_consultas_api.Data.ServiceDto.Response;

namespace mais_consultas_api.Data.ProfessionalDto.Response
{
    public class ProfessionalResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ServiceResponse Service { get; set; }
        public ProviderReadResponse Provider { get; set; }
    }
}