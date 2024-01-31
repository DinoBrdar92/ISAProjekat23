using ISAProjekat23.Repository.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISAProjekat23.Server.Controllers.Appointment
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;

        private IAppointmentsRepository _appointmentsRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentsRepository appointmentsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _appointmentsRepository = appointmentsRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllAppointments")]
        public async Task<IEnumerable<Model.Domain.Appointment>> GetAllAppointments()
        {
            return await _appointmentsRepository.GetAllAppointments();
        }

        [Authorize]
        [HttpPost]
        [Route("AddAppointment")]
        public async Task<bool> AddAppointment([FromBody] Model.Domain.Appointment appointment)
        {
            return await _appointmentsRepository.AddAppointment(appointment);
        }

        /**
        [Authorize]
        [HttpGet]
        [Route("ReserveAppointment")]
        public async Task<bool> ReserveAppointment([FromQuery]int appointmentId, [FromQuery]int userId)
        {
            return await _appointmentsRepository.ReserveAppointment(appointmentId, userId);
        }

        [Authorize]
        [HttpGet]
        [Route("CancelAppointment")]
        public async Task<bool> CancelAppointment([FromQuery] int appointmentId)
        {
            return await _appointmentsRepository.CancelAppointment(appointmentId);
        }
        */
    }
}