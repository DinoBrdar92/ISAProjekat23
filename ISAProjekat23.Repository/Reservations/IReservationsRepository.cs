using ISAProjekat23.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Repository.Reservations
{
    public interface IReservationsRepository
    {
        Task<bool> AddReservation(Reservation reservation);
        Task<List<Reservation>> GetAllReservations();
        Task<bool> ScheduleReservation(int reservationId, int userId);
        Task<bool> CancelReservation(int reservationId);
    }
}
