using ISAProjekat23.Model.Domain;
using ISAProjekat23.Repository.Reservations;
using ISAProjekat23.Repository.Complaints;
using ISAProjekat23.Repository.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        [Route("AddReservation")]
        public async Task<bool> AddReservation([FromBody] Model.Domain.Reservation reservation)
        {
            return await _reservationsRepository.AddReservation(reservation);
        }

        [Authorize]
        [HttpGet]
        [Route("ScheduleReservation")]
        public async Task<bool> ScheduleReservation([FromQuery]int reservationId, [FromQuery]int userId)
        {
            return await _reservationsRepository.ScheduleReservation(reservationId, userId);
        }

        [Authorize]
        [HttpGet]
        [Route("CancelReservation")]
        public async Task<bool> CancelReservation([FromQuery] int reservationId)
        {
            return await _reservationsRepository.CancelReservation(reservationId);
        }
    }
}