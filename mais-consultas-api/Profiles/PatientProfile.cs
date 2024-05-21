using AutoMapper;
using mais_consultas_api.Data.ProfileDto.Responses;
using mais_consultas_api.Models;

namespace mais_consultas_api.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientResponse>();
        }
    }
}