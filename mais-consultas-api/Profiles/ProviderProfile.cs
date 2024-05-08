using AutoMapper;
using mais_consultas_api.Data.Provider.Responses;

namespace mais_consultas_api.Data.Provider.Profiles
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Models.Provider, ProviderReadResponse>();
        }
    }
}