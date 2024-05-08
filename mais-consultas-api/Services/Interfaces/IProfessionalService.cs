using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IProfessionalService
    {
        Professional Add (string name, string service, int idProvider);
        void Remove (int id);
        Professional Update (int id, string name, string service, int idProvider);
        Professional Get (int id);
        IEnumerable<Professional> GetAll ();
    }
}
