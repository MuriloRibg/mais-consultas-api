using AutoMapper;
using mais_consultas_api.Data.AddressDto.Response;
using mais_consultas_api.Data.ProviderDto.Requests;
using mais_consultas_api.Data.ProviderDto.Responses;
using mais_consultas_api.Models;

namespace mais_consultas_api.Profiles
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderReadResponse>();
            CreateMap<ProviderInsertRequest, Provider>();
            CreateMap<ProviderUpdateRequest, Provider>();
            CreateMap<Address, AddressResponse>();
        }
    }
}