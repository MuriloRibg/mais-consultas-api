﻿namespace mais_consultas_api.Data.AppointmentDto.Requests
{
    public class AppointmentUpdateRequest
    {
        public DateTime DateTime { get; set; }
        public int ProfessionalId { get; set; }
        public int ProviderId { get; set; }
        public int PatientId { get; set; }
    }
}
