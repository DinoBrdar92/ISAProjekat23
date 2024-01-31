using ISAProjekat23.Model.Domain;
using ISAProjekat23.Repository.Users;
using ISAProjekat23.Server.Controllers.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ISAProjekat23.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private IUsersRepository _userRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ILogger<UserController> logger, IUsersRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
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
        public async Task<ActionResult?> Login([FromBody] LoginCredentials loginCred)
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
                    new Claim(ClaimTypes.Name, user.Id.ToString())
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
        public async Task<bool> Register([FromBody] User potentialUser)
        {
            var userDto = await _userRepository.RegisterUser(potentialUser);
            if (userDto != null)
            {

                string verificationUrl = $"https://localhost:7241/User/Verify?id={userDto.Id}&name={userDto.FirstName}";
                string body = $"<body style='font-family: 'Arial', sans-serif;'><div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ccc; border-radius: 5px;'><h2 style='color: #3a1f8f;'>Account Verification</h2><p>Welcome to Our Website! To complete your registration, please click the link below to verify your account:</p><p><a href='{verificationUrl}' style='display: inline-block; padding: 10px 20px; background-color: #3c0047; color: #fff; text-decoration: none; border-radius: 3px;'>Verify Your Account</a></p><p>If you did not sign up for an account on Our Website, you can safely ignore this email.</p><p>Thank you,<br>The MESS Team</p></div></body>";
                await Email.SendVerificationEmail($"Hi {userDto.FirstName}, Please verify your account", body, userDto.Email);

                //await Email.SendQRCodeEmail("Verify your account", "link za verifikaciju", potentialUser.Email);
                return true;
            }
            return false;
        }

        [HttpGet]
        [Route("Verify")]
        public async Task<string> Verify([FromQuery] string id, [FromQuery] string name)
        {
            bool operationSuccessful = await _userRepository.VerifyUser(id, name);

            if (operationSuccessful)
            {
                return "Account verified! You can close this page and proceed to login.";
            }
            else
            {

            }
            return "There was something wrong with your verification!";
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<User?> GetUser()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                int Id = Int32.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
                User user = await _userRepository.GetUser(Id);

                return user;
            }
            else
            {
                return null;
            }

        }


        [HttpGet]
        [Route("GetAllCompanyAdmins")]
        public async Task<List<User>> GetAllCompanyUsers([FromQuery] int companyId)
        {
            return await _userRepository.GetAllCompanyAdmins(companyId);
        }


        [HttpGet]
        [Route("LogOut")]
        public async Task LogOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync("MyAuthScheme");
        }
    }
}