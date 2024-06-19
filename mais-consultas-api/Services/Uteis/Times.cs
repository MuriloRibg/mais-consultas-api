using mais_consultas_api.Data.AppointmentDto.Responses;

namespace mais_consultas_api.Services.Uteis;

public static class Times
{
    public static IList<AppointmentTimesResponse>  GetResponsesTimes()
    {
        IList<AppointmentTimesResponse> horarios = new List<AppointmentTimesResponse>();
        TimeSpan horaInicial = new TimeSpan(8, 0, 0);
        TimeSpan horaFinal = new TimeSpan(17, 30, 0);

        int sequencial = 1;
        for (TimeSpan horaAtual = horaInicial;
             horaAtual <= horaFinal;
             horaAtual = horaAtual.Add(new TimeSpan(0, 30, 0)))
        {
            horarios.Add(new AppointmentTimesResponse
            {
                Id = sequencial,
                Available = true,
                Time = horaAtual.ToString(@"hh\:mm")
            });
            sequencial++;
        }

        return horarios;
    }
}