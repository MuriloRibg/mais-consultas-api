using mais_consultas_api.Data.Provider.Requests;
using mais_consultas_api.Data.Provider.Responses;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IProviderService
    {
        List<ProviderReadResponse> List();
        ProviderReadResponse Insert(ProviderInsertRequest providerInsertRequest);
        ProviderReadResponse Update(ProviderUpdateRequest providerUpdateRequest, int id);
        void Delete(int idProvider);
    }
}