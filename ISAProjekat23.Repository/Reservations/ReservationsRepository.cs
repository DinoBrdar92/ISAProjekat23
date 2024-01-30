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

namespace ISAProjekat23.Repository.Reservations
{
    public class ReservationsRepository : IReservationsRepository
    {
        private DatabaseContext databaseContext;

        public ReservationsRepository(DatabaseContext dc)
        {
            databaseContext = dc;
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            var apps = await databaseContext.Reservations.Include(x => x.User).ToListAsync();
                
            return apps.Select(r => new Reservation()
                    {
                        Id = r.Id,
                        Start = r.Start,
                        Duration = r.Duration,
                        HandledBy = UserRepository.CreateDomainFromEntity(r.Admin),
                        ReservedBy = UserRepository.CreateDomainFromEntity(r.User)
                    })
                    .ToList();
        }

        public async Task<bool> AddReservation(Reservation reservation)
        {
            databaseContext.Reservations.Add(CreateEntityFromDomain(reservation));
            await databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ScheduleReservation(int reservationId, int userId)
        {
            var reservation = await databaseContext.Reservations.FirstOrDefaultAsync(a => a.Id == reservationId);
            reservation.ReservedBy = userId;
            await databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelReservation(int reservationId)
        {
            var reservation = await databaseContext.Reservations.FirstOrDefaultAsync(a => a.Id == reservationId);
            reservation.ReservedBy = null;
            await databaseContext.SaveChangesAsync();
            return true;
        }


        public ReservationDto CreateEntityFromDomain(Reservation reservation)
        {
            ReservationDto reservationDto = new ReservationDto()
            {
                Id = reservation.Id,
                Start = reservation.Start,
                Duration = reservation.Duration,
                ReservedBy = reservation.ReservedBy?.Id,

            };

            return reservationDto;
        }

        public Reservation CreateDomainFromEntity(ReservationDto reservationDto)
        {
            Reservation reservation = new Reservation()
            {
                Id = reservationDto.Id,
                Start = reservationDto.Start,
                Duration = reservationDto.Duration,
                //TODO: nacin da preko Id-ja dobijem User-a
                //ReservedBy = 

        };

            return reservation;
        }
    }
}
