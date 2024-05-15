using AutoMapper;
using mais_consultas_api.Data;
using mais_consultas_api.Data.Provider.Requests;
using mais_consultas_api.Data.Provider.Responses;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;

namespace mais_consultas_api.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ProviderService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<ProviderReadResponse> List()
        {
            List<Provider> providers = _context.Providers.ToList();
            return _mapper.Map<List<ProviderReadResponse>>(providers);
        }

        public ProviderReadResponse Insert(ProviderInsertRequest providerInsertRequest)
        {
            Provider provider = _mapper.Map<Provider>(providerInsertRequest);
            _context.Add(provider);
            _context.SaveChanges();
            return _mapper.Map<ProviderReadResponse>(provider);
        }

        public ProviderReadResponse Update(ProviderUpdateRequest providerUpdateRequest, int id)
        {
            Provider provider = _context.Providers.FirstOrDefault(p => p.Id == id);
            if (provider is null) throw new Exception("Provider não encontrado!");

            provider.SetName(providerUpdateRequest.Name);
            provider.SetEmail(providerUpdateRequest.Email);
            provider.SetCnpj(providerUpdateRequest.Cnpj);
            provider.SetPhoneNumber(providerUpdateRequest.PhoneNumber);

            _context.SaveChanges();
            return _mapper.Map<ProviderReadResponse>(provider);
        }

        public void Delete(int idProvider)
        {
            Provider provider = _context.Providers.FirstOrDefault(p => p.Id == idProvider);
            if (provider is null) throw new Exception("Provider não encontrado!");

            _context.Remove(provider);
            _context.SaveChanges();
        }
    }
}
