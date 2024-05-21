using mais_consultas_api.Data.ProfessionalDto.Response;
using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IProfessionalService
    {
        ProfessionalResponse Add (string name, int idService, int idProvider);
        void Remove (int id);
        Professional Update (int id, string name, int idService, int idProvider);
        Professional? Get (int id);
        IEnumerable<Professional> GetAll ();
    }
}
