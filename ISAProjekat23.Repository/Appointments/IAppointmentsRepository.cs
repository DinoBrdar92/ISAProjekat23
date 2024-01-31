using ISAProjekat23.Model.Domain;

namespace ISAProjekat23.Repository.Appointments
{
    public interface IAppointmentsRepository
    {
        Task<bool> AddAppointment(Appointment appointment);
        Task<List<Appointment>> GetAllAppointments();
        /**
        Task<bool> ReserveAppointment(int appointmentId, int userId);
        Task<bool> CancelAppointment(int appointmentId);
        */
    }
}
