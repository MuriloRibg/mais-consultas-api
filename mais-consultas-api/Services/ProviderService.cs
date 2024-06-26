using AutoMapper;
using mais_consultas_api.Data;
using mais_consultas_api.Data.ProviderDto.Requests;
using mais_consultas_api.Data.ProviderDto.Responses;
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

        public List<ProviderReadResponse> List(long? idService)
        {
            IQueryable<Provider> providers = _context.Providers.AsQueryable();

            if (idService is > 0)
                providers = providers.Where(p => p.Professional.Service.Id == idService);
                
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
            if (provider is null) throw new Exception("ProviderDto não encontrado!");

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
            if (provider is null) throw new Exception("ProviderDto não encontrado!");

            _context.Remove(provider);
            _context.SaveChanges();
        }
    }
}
