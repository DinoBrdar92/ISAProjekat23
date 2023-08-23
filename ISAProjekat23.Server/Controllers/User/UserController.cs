using ISAProjekat23.Model.Domain;
using ISAProjekat23.Repository.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ISAProjekat23.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        
        private IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
          return await _userRepository.GetAllUsers();
        }

        //[Route("/GetUser/{id}")]s
        //public IEnumerable<User> GetUser(string id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        [Route("Login")]
        public async Task<User> Login([FromBody]User potentialUser)
        {
            User user;
            user = await _userRepository.GetUser(potentialUser);
            return user;
        }
    }
}