namespace mais_consultas_api.Data.ProviderDto.Requests
{
    public record ProviderInsertRequest
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}