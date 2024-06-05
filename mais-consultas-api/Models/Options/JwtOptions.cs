namespace mais_consultas_api.Models.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpiresInSeconds { get; set; }
    }
}
