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
            var apps = await databaseContext.Appointments.Include(x => x.User).ToListAsync();
                
            return apps.Select(a => new Appointment()
                    {
                        Id = a.Id,
                        Start = a.Start,
                        Duration = a.Duration,
                        ReservedBy = UserRepository.CreateDomainFromEntity(a.User)
                    })
                    .ToList();
        }

        public async Task<bool> AddAppointment(Appointment appointment)
        {
            databaseContext.Appointments.Add(CreateEntityFromDomain(appointment));
            await databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ReserveAppointment(int appointmentId, int userId)
        {
            var appointment = await databaseContext.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
            appointment.ReservedBy = userId;
            await databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelAppointment(int appointmentId)
        {
            var appointment = await databaseContext.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
            appointment.ReservedBy = null;
            await databaseContext.SaveChangesAsync();
            return true;
        }


        public AppointmentDto CreateEntityFromDomain(Appointment appointment)
        {
            AppointmentDto appointmentDto = new AppointmentDto()
            {
                Id = appointment.Id,
                Start = appointment.Start,
                Duration = appointment.Duration,
                ReservedBy = appointment.ReservedBy?.Id,

            };

            return appointmentDto;
        }

        public Appointment CreateDomainFromEntity(AppointmentDto appointmentDto)
        {
            Appointment appointment = new Appointment()
            {
                Id = appointmentDto.Id,
                Start = appointmentDto.Start,
                Duration = appointmentDto.Duration,
                //TODO: nacin da preko Id-ja dobijem User-a
                //ReservedBy = 

        };

            return appointment;
        }
    }
}
