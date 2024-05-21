using AutoMapper;
using mais_consultas_api.Data.AppointmentDto.Responses;
using mais_consultas_api.Models;

namespace mais_consultas_api.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentResponse>();
        }
    }
}