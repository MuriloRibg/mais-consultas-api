using mais_consultas_api.Data.ProfessionalDto.Response;
using mais_consultas_api.Data.ProfileDto.Responses;
using mais_consultas_api.Data.ProviderDto.Responses;
using mais_consultas_api.Models.Enumerators;

namespace mais_consultas_api.Data.AppointmentDto.Responses
{
    public class AppointmentResponse
    {
        public int Id { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public DateTime DateTime { get; set; }
        public ProfessionalResponse Professional { get; set; }
        public ProviderReadResponse Provider { get; set; }
        public PatientResponse Patient { get; set; }
    }
}