using AutoMapper;
using mais_consultas_api.Data.ProfessionalDto.Response;
using mais_consultas_api.Models;

namespace mais_consultas_api.Profiles
{
    public class ProfessionalProfile : Profile
    {
        public ProfessionalProfile()
        {
            CreateMap<Professional, ProfessionalResponse>();
        }
    }
}