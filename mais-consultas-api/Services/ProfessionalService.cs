using AutoMapper;
using mais_consultas_api.Data;
using mais_consultas_api.Data.ProfessionalDto.Response;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;

namespace mais_consultas_api.Services
{
    public class ProfessionalService(AppDbContext context, IMapper mapper) : IProfessionalService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public ProfessionalResponse Add(string name, int idService, int idProvider)
        {
            Provider? provider = _context.Providers.FirstOrDefault(p => p.Id == idProvider);
            if (provider is null) throw new Exception("ProviderDto não encontrado");
            Service? service = _context.Services.FirstOrDefault(s => s.Id == idService);
            if (service is null) throw new Exception("ServiceDto não encontrado");
            
            Professional professional = new(name, service, provider);
            
            _context.Add(professional);
            _context.SaveChanges();
            ProfessionalResponse response = _mapper.Map<ProfessionalResponse>(professional);
            
            return response;
        }

        public IEnumerable<Professional> GetAll()
        {
            return _context.Professionals.AsEnumerable();
        }

        public Professional? Get(int id)
        {
            return _context.Professionals.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Professional professional = _context.Professionals.Where(y => y.Id == id).First();
            _context.Professionals.Remove(professional);
            _context.SaveChanges();
        }

        public Professional Update(int id, string name, int idService, int idProvider)
        {
            Provider? provider = _context.Providers.FirstOrDefault(p => p.Id == idProvider);
            if (provider is null) throw new Exception("ProviderDto não encontrado");
            Service? service = _context.Services.FirstOrDefault(s => s.Id == idService);
            if (service is null) throw new Exception("ServiceDto não encontrado");
            
            Professional professional = _context.Professionals.First(y => y.Id == id);
            professional.SetName(name);
            professional.SetService(service);
            professional.SetProvider(provider);

            _context.Professionals.Update(professional);

            _context.SaveChanges();
            return professional;
        }
    }
}