using AutoMapper;
using mais_consultas_api.Data.ProviderDto.Requests;
using mais_consultas_api.Data.ProviderDto.Responses;

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