using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Patient patient);
    }
}
