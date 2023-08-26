using ISAProjekat23.Model.Domain;
using ISAProjekat23.Repository.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ISAProjekat23.Repository.Complaints;

namespace ISAProjekat23.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComplaintController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        
        private IComplaintsRepository _complaintsRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ComplaintController(ILogger<UserController> logger, IComplaintsRepository complaintsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _complaintsRepository = complaintsRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<bool> CreateComplaint([FromBody]Complaint complaint)
        {
            return await _complaintsRepository.AddComplaint(complaint);
        }
    }
}