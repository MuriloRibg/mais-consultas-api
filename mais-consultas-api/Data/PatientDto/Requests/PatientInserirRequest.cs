namespace mais_consultas_api.Data.PatientDto.Requests
{
   public class PatientInserirRequest
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}