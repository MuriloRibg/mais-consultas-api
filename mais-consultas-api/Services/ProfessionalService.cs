using mais_consultas_api.Data;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;

namespace mais_consultas_api.Services
{
    public class ProfessionalService(AppDbContext context) : IProfessionalService
    {
        private readonly AppDbContext _context = context;

        public Professional Add(string name, int idService, int idProvider)
        {
            Provider provider = _context.Providers.FirstOrDefault(p => p.Id == idProvider);
            if (provider is null) throw new Exception("Provider não encontrado");
            Service service = _context.Services.FirstOrDefault(s => s.Id == idService);
            if (service is null) throw new Exception("Service não encontrado");
            
            Professional professional = new(name, idService, idProvider);

            _context.Add(professional);
            _context.SaveChanges();
            return professional;
        }

        public IEnumerable<Professional> GetAll()
        {
            return _context.Professionals.AsEnumerable();
        }

        public Professional Get(int id)
        {
            return _context.Professionals.Where(x => x.Id == id).First();
        }

        public void Remove(int id)
        {
            Professional professional = _context.Professionals.Where(y => y.Id == id).First();
            _context.Professionals.Remove(professional);
            _context.SaveChanges();
        }

        public Professional Update(int id, string name, int idService, int idProvider)
        {
            Provider provider = _context.Providers.FirstOrDefault(p => p.Id == idProvider);
            if (provider is null) throw new Exception("Provider não encontrado");
            Service service = _context.Services.FirstOrDefault(s => s.Id == idService);
            if (service is null) throw new Exception("Service não encontrado");
            
            Professional professional = _context.Professionals.Where(y => y.Id == id).First();
            professional.SetName(name);
            professional.SetService(idProvider);
            professional.SetProvider(idService);

            _context.Professionals.Update(professional);

            _context.SaveChanges();
            return professional;
        }
    }
}