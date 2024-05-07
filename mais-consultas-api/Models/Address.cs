using System.ComponentModel.DataAnnotations;

namespace mais_consultas_api.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        [StringLength(100)]
        public string LineOne {get; set;}
        [StringLength(100)]
        public string LineTwo {get; set;}
        [Required]
        [StringLength(8)]
        public string ZipCode {get; set;}
        [Required]
        [StringLength(50)]
        public string City {get; set;}
        [Required]
        [StringLength(50)]
        public string State {get; set;}
    
        public Address(string lineOne, string lineTwo, string zipCode, string city, string state)
        {
            SetLineOne(lineOne);
            SetLineTwo(lineTwo);
            SetZipCode(zipCode);
            SetCity(city);
            SetState(state);
        }
    
        public void SetLineOne(string lineOne){
            LineOne = lineOne;
        }
    
        public void SetLineTwo(string lineTwo){
            LineTwo = lineTwo;
        }
    
        public void SetZipCode(string zipCode){
            ZipCode = zipCode;
        }
    
        public void SetCity(string city){
            City = city;
        }
    
        public void SetState(string state){
            State = state;
        }
    }
}