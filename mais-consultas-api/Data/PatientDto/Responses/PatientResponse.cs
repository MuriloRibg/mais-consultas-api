namespace mais_consultas_api.Data.ProfileDto.Responses
{
    public class PatientResponse
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Email { get; set; }
    }
}