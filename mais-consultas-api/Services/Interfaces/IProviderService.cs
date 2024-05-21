using mais_consultas_api.Data.ProviderDto.Requests;
using mais_consultas_api.Data.ProviderDto.Responses;

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