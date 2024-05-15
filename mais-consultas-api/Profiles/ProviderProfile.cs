using AutoMapper;
using mais_consultas_api.Data.Provider.Requests;
using mais_consultas_api.Data.Provider.Responses;

namespace mais_consultas_api.Profiles
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Models.Provider, ProviderReadResponse>();
            CreateMap<ProviderInsertRequest, Models.Provider>();
            CreateMap<ProviderUpdateRequest, Models.Provider>();
        }
    }
}