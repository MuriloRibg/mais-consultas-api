using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace mais_consultas_api.Models
{
    public class Professional
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("Service")] 
        public int Id_Service { get; set; }
        public Service Service { get; set; } 

        [ForeignKey("Provider")] 
        public int Id_Provider { get; set; }
        public Provider Provider { get; set; }
        
        [JsonIgnore]
        public Appointment Appointment { get; set; }

        public Professional()
        {
            
        }
        
        public Professional(string name, Service service, Provider provider)
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

        public void SetService(Service service)
        {
            Id_Service = service.Id;
        }

        public void SetProvider(Provider provider)
        {
            Id_Provider = provider.Id;
        }
    }
}
