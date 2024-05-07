using AutoMapper;
using FluentResults;
using mais_consultas_api.Data;
using mais_consultas_api.Data.Provider.Requests;
using mais_consultas_api.Data.Responses;
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
            List<Provider> providers = _context.Provider.ToList();
            return _mapper.Map<List<ProviderReadResponse>>(providers);
        }

        public ProviderReadResponse Insert(ProviderInsertRequest providerCreateRequest)
        {
            Provider provider = _mapper.Map<Provider>(providerCreateRequest);
            _context.Add(provider);
            _context.SaveChanges();
            return _mapper.Map<ProviderReadResponse>(provider);
        }

        public Result Update(ProviderUpdateRequest providerUpdateRequest, int id)
        {
            Provider aula = _context.Provider.FirstOrDefault(p => p.Id == id);

            if (aula is null) return Result.Fail("Provider não encontrado!");

            _mapper.Map(providerUpdateRequest, aula);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result Delete(int idProvider)
        {
            Provider provider = _context.Provider.FirstOrDefault(p => p.Id == idProvider);

            if (provider is null) return Result.Fail("Provider não encontrado!");

            _context.Remove(provider);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}