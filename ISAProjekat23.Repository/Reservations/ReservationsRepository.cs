using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Entities;

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
            //TODO: vratiti listu svih rezervacija samo za tog korisnika
            return null;
        }

        public async Task<List<Reservation>> GetReservationsByCompany(int companyId)
        {
            //TODO: vratiti listu svih rezervacija samo za tu kompaniju
            return null;
        }

        public async Task<bool> ScheduleReservation(int companyId, int productId, int appointmentId, int reservedById)
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

    }
}
