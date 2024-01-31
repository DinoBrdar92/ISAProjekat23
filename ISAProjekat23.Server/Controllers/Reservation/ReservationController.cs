using ISAProjekat23.Repository.Reservations;
using ISAProjekat23.Server.Controllers.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISAProjekat23.Server.Controllers.Reservation
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private IReservationsRepository _reservationsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReservationController(ILogger<ReservationController> logger, IReservationsRepository reservationsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _reservationsRepository = reservationsRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllReservations")]
        public async Task<IEnumerable<Model.Domain.Reservation>> GetAllReservations()
        {
            return await _reservationsRepository.GetAllReservations();
        }

        [Authorize]
        [HttpGet]
        [Route("GetReservationsByUser")]
        public async Task<IEnumerable<Model.Domain.Reservation>> GetReservationsByUser([FromQuery] int userId)
        {
            return await _reservationsRepository.GetReservationsByUser(userId);
        }


        [Authorize]
        [HttpGet]
        [Route("GetReservationsByCompany")]
        public async Task<IEnumerable<Model.Domain.Reservation>> GetReservationsByCompany([FromQuery] int companyId)
        {
            return await _reservationsRepository.GetReservationsByCompany(companyId);
        }

        [Authorize]
        [HttpGet]
        [Route("ScheduleReservation")]
        public async Task<bool> ScheduleReservation([FromQuery] int productId, [FromQuery] int appointmentId, [FromQuery] int reservedById, [FromQuery] string email)
        {

            var operationSuccessful = await _reservationsRepository.ScheduleReservation(productId, appointmentId, reservedById);

            if (operationSuccessful)
            {
                string body = productId + ", " + appointmentId;
                await Email.SendQRCodeEmail("Your reservation is complete!", body, email);
            }

            return true;
        }

        [Authorize]
        [HttpGet]
        [Route("CancelReservation")]
        public async Task<bool> CancelAppointment([FromQuery] int reservationId)
        {
            return await _reservationsRepository.CancelReservation(reservationId);
        }

    }
}
