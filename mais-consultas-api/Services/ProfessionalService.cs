using mais_consultas_api.Data;
using mais_consultas_api.Services.Interfaces;

namespace mais_consultas_api.Services
{
    public class ProfessionalService (AppDbContext context) : IProfessionalService
    {
        private readonly AppDbContext _context = context;

        public Professional Add(string name, string service, string provider)
        {
            Professional professional = new(name, service, provider);

            _context.Professionals.Add(professional);

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
        }

        public Professional Update(int id, string name, string service, string provider)
        {
            Professional professional = _context.Professionals.Where(y => y.Id == id).First();
            professional.SetName(name);
            professional.SetService(service);
            professional.SetProvider(provider);
            
            _context.Professionals.Update(professional);
            return professional;
        }
    }
}
