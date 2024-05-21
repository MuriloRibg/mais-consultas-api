using AutoMapper;
using mais_consultas_api.Data.ServiceDto.Response;
using mais_consultas_api.Models;

namespace mais_consultas_api.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceResponse>();
        }
    }
}