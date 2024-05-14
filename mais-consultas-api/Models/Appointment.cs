using mais_consultas_api.Models.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mais_consultas_api.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; protected set; }

        [Required]
        public AppointmentStatusEnum Status { get; protected set; }

        [Required]
        public DateTime DateTime { get; protected set; }

        [ForeignKey("Professional")]
        public int ProfessionalId { get; protected set; }

        [Required]
        public Professional Professional { get; protected set; }

        [ForeignKey("Provider")]
        public int ProviderId { get; set; }

        [Required]
        public Provider Provider { get; protected set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Required]
        public Patient Patient { get; set; }

        public Appointment(DateTime dateTime, Professional professional, Provider provider, Patient patient)
        {
            SetStatus(AppointmentStatusEnum.Scheduled);
            SetDateTime(dateTime);
            SetProfessional(professional);
            SetProvider(provider);
            SetPatient(patient);
        }

        public void SetStatus(AppointmentStatusEnum status)
        {
            if (!Enum.IsDefined(typeof(AppointmentStatusEnum), status))
                throw new ArgumentException("Invalid appointment status.", nameof(status));

            Status = status;
        }

        public void SetDateTime(DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
                throw new ArgumentException("The appointment date must not be in the past.", nameof(dateTime));

            DateTime = dateTime;
        }

        public void SetProfessional(Professional professional)
        {
            Professional = professional;
            ProfessionalId = professional.Id;
        }

        public void SetProvider(Provider provider)
        {
            Provider = provider;
            ProviderId = provider.Id;
        }

        public void SetPatient(Patient patient)
        {
            Patient = patient;
            PatientId = patient.Id;
        }

        internal void SetStatus(object canceled)
        {
            throw new NotImplementedException();
        }
    }
}
