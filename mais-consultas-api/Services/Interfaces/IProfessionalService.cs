namespace mais_consultas_api.Services.Interfaces
{
    public interface IProfessionalService
    {
        Professional Add (string name, string service, string provider);
        void Remove (int id);
        Professional Update (int id, string name, string service, string provider);
        Professional Get (int id);
        IEnumerable<Professional> GetAll ();
    }
}
