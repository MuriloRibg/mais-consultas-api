using FluentResults;
using mais_consultas_api.Data.Provider.Requests;
using mais_consultas_api.Data.Provider.Responses;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IProviderService
    {
        List<ProviderReadResponse> List();
        ProviderReadResponse Insert(ProviderInsertRequest providerCreateRequest);
        Result Update(ProviderUpdateRequest providerUpdateRequest, int id);
        Result Delete(int idProvider);
    }
}