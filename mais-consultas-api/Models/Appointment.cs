﻿using mais_consultas_api.Models.Enumerators;
using System.ComponentModel.DataAnnotations;

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
        
        [Required]
        public int Id_Professional { get; protected set; }
        
        public virtual Professional Professional { get; protected set; }
        
        [Required]
        public int Id_Provider { get; set; }

        public virtual Provider Provider { get; protected set; }
        
        [Required]
        public int Id_Patient { get; set; }

        public virtual Patient Patient { get; set; }

        public Appointment()
        {
            
        }

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
            Id_Professional = professional.Id;
        }

        public void SetProvider(Provider provider)
        {
            Provider = provider;
            Id_Provider = provider.Id;
        }

        public void SetPatient(Patient patient)
        {
            Patient = patient;
            Id_Patient = patient.Id;
        }

        internal void SetStatus(object canceled)
        {
            throw new NotImplementedException();
        }
    }
}
