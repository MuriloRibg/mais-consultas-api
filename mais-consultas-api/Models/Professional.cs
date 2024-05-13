using System.ComponentModel.DataAnnotations;

namespace mais_consultas_api.Models
{
    public class Professional
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public int Id_Provider { get; set; }
        public virtual Provider Provider { get; set; }

        public Professional()
        {
            
        }
        public Professional(string name, string service, Provider provider)
        {
            SetName(name);
            SetService(service);
            SetProvider(provider);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name");

            Name = name;
        }

        public void SetService(string service)
        {
            Service = service;
        }

        public void SetProvider(Provider provider)
        {
            Provider = provider;
        }
    }
}
