using ISAProjekat23.Model.Domain;
using ISAProjekat23.Repository.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace ISAProjekat23.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        
        private IUserRepository _userRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<ActionResult?> Login([FromBody]LoginCredentials loginCred)
        {
            User? user;
            user = await _userRepository.GetUser(loginCred);

            if (user != null)
            {
                //TODO: nakaciti cookie na sesiju
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(claims, "MyAuthScheme");

                await _httpContextAccessor.HttpContext.SignInAsync("MyAuthScheme",
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties());

                return Ok(user);
            }
            else
            {
                return Ok(null);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<bool> Register([FromBody]User potentialUser)
        {
            bool operationSuccessful;
            operationSuccessful = await _userRepository.RegisterUser(potentialUser);
            return operationSuccessful;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<User?> GetUser()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var Id = _httpContextAccessor.HttpContext.User.Identity.Name;
                User user = await _userRepository.GetUser(Id);

                return user;
            }
            else
            {
                return null;
            }

        }
    }
}