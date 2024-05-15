using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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
        public int Id_Service { get; set; }
        public virtual Service Service { get; set; }

        [Required]
        public int Id_Provider { get; set; }
        public virtual Provider Provider { get; set; }
        
        [JsonIgnore] 
        public virtual Appointment Appointment { get; set; }

        public Professional()
        {
            
        }
        
        public Professional(string name, int idService, int IdProvider)
        {
            SetName(name);
            SetService(idService);
            SetProvider(IdProvider);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name");

            Name = name;
        }

        public void SetService(int idService)
        {
            Id_Service = idService;
        }

        public void SetProvider(int IdProvider)
        {
            Id_Provider = IdProvider;
        }
    }
}
