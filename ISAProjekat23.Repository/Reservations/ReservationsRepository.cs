using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Entities;
using Microsoft.EntityFrameworkCore;

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
            //TODO: vratiti listu svih rezervacija (da li uopste treba?)
            return null;
        }

        public async Task<List<Reservation>> GetReservationsByUser(int userId)
        {
            return await databaseContext.Reservations
                .Include(x => x.Product)
                .Include(x => x.Appointment)
                .Where(x => x.ReservedBy == userId && x.TimeCancelled == null)
                .Select(x => new Reservation()
                {
                    Id = x.Id,
                    TimeReserved = x.TimeReserved,
                    TimeCancelled = x.TimeCancelled,
                    Product = new Product()
                    {
                        Id = x.Product.Id,
                        Name = x.Product.Name,
                        Description = x.Product.Description,
                    },
                    Appointment = new Appointment()
                    {
                        Id = x.Appointment.Id,
                        Duration = x.Appointment.Duration,
                        Start = x.Appointment.Start,
                    }
                })
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCompany(int companyId)
        {
            //TODO: vratiti listu svih rezervacija samo za tu kompaniju
            return null;
        }

        public async Task<bool> ScheduleReservation(int productId, int appointmentId, int reservedById)
        {
            var reservation = new ReservationDto()
            {
                ProductId = productId,
                AppointmentId = appointmentId,
                ReservedBy = reservedById,
                TimeReserved = DateTime.Now,
            };

            databaseContext.Reservations.Add(reservation);
            await databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelReservation(int reservationId)
        {
            var reservationDto = await databaseContext.Reservations.FirstOrDefaultAsync(x => x.Id == reservationId);
            DateTime now = DateTime.Now;
            reservationDto.TimeCancelled = now;
            //TODO: dodati logiku za dodavanje bodova
            /*
            if (IsLessThan24h(reservationDto.Appointment.Start))
            {
                reservationDto.User.PenaltyPoints += 2;
            }
            else
            {
                reservationDto.User.PenaltyPoints += 1;
            }
            */
            await databaseContext.SaveChangesAsync();

            return true;
        }

        private bool IsLessThan24h(DateTime start)
        {
            return (start - DateTime.Now).TotalHours < 24;
        }

    }
}
