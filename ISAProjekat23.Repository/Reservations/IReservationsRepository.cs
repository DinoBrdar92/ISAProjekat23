using ISAProjekat23.Model.Domain;

namespace ISAProjekat23.Repository.Reservations
{
    public interface IReservationsRepository
    {
        Task<List<Reservation>> GetAllReservations();
        Task<List<Reservation>> GetReservationsByUser(int userId);
        Task<List<Reservation>> GetReservationsByCompany(int companyId);
        Task<bool> ScheduleReservation(int companyId, int productId, int appointmentId, int reservedById);
    }
}
