using ISAProjekat23.Model.Domain;
using ISAProjekat23.Repository.Appointments;
using ISAProjekat23.Repository.Complaints;
using ISAProjekat23.Repository.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    }
}