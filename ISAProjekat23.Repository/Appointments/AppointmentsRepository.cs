using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Entities;
using ISAProjekat23.Repository.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Repository.Appointments
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private DatabaseContext databaseContext;

        public AppointmentsRepository(DatabaseContext dc)
        {
            databaseContext = dc;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await databaseContext.Appointments.Select(a => new Appointment()
            {
                Date = DateOnly.FromDateTime(a.Start),
                Time = TimeOnly.FromDateTime(a.Start),
                Duration = a.Duration,
            })
                .ToListAsync();
        }

        public async Task<bool> AddAppointment(Appointment appointment)
        {
            databaseContext.Appointments.Add(CreateEntityFromDomain(appointment));
            await databaseContext.SaveChangesAsync();

            return true;
        }

        public AppointmentDto CreateEntityFromDomain(Appointment appointment)
        {
            AppointmentDto appointmentDto = new AppointmentDto()
            {
                Start = appointment.Date.ToDateTime(appointment.Time),
                Duration = appointment.Duration,
                ReservedBy = appointment.ReservedBy?.Id,

            };

            return appointmentDto;
        }

        public Appointment CreateDomainFromEntity(AppointmentDto appointmentDto)
        {
            Appointment appointment = new Appointment()
            {
                Date = DateOnly.FromDateTime(appointmentDto.Start),
                Time = TimeOnly.FromDateTime(appointmentDto.Start),
                Duration = appointmentDto.Duration,
                //TODO: nacin da preko Id-ja dobijem User-a
                //ReservedBy = 

        };

            return appointment;
        }
    }
}
