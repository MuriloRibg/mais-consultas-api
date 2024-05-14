using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IServiceService
    {
        Service Add(decimal price, string name);
        IEnumerable<Service> GetAll();
        Service Get(int id);
        void Remove(int id);
        Service Update(int id, decimal price, string name);
    }
}
