namespace mais_consultas_api.Data.Responses;

public class ProviderReadResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime? DeleteAt { get; set; } 
}