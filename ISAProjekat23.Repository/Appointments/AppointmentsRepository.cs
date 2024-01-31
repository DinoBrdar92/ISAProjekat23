using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Entities;
using ISAProjekat23.Repository.Companies;
using ISAProjekat23.Repository.Users;
using Microsoft.EntityFrameworkCore;

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
            var apps = await databaseContext.Appointments.Include(x => x.Admin).ToListAsync();

            return apps.Select(a => new Appointment()
            {
                Id = a.Id,
                Start = a.Start,
                Duration = a.Duration,
                HandledById = a.HandledBy,
                CompanyId = a.CompanyId,
                HandledBy = new User()
                {
                    Id = a.Admin.Id,
                    FirstName = a.Admin.FirstName,
                    LastName = a.Admin.LastName
                },
                Company = new Company()
                {
                    Id = a.CompanyId
                },
            })
            .ToList();
        }

        public async Task<bool> AddAppointment(Appointment appointment)
        {
            databaseContext.Appointments.Add(CreateEntityFromDomain(appointment));
            await databaseContext.SaveChangesAsync();

            return true;
        }

        /**
         * ovo sad treba u rezervaciju
         * 
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
        */

        public AppointmentDto CreateEntityFromDomain(Appointment appointment)
        {
            AppointmentDto appointmentDto = new AppointmentDto()
            {
                Id = appointment.Id,
                Start = appointment.Start,
                Duration = appointment.Duration,
                HandledBy = appointment.HandledById,
                CompanyId = appointment.CompanyId

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
                HandledById = appointmentDto.HandledBy,
                CompanyId = appointmentDto.CompanyId,
                HandledBy = UsersRepository.CreateDomainFromEntity(appointmentDto.Admin),
                Company = CompaniesRepository.CreateDomainFromEntity(appointmentDto.Company)
                //TODO: nacin da preko Id-ja dobijem User-a
                //ReservedBy = 

            };

            return appointment;
        }
    }
}
