//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using System;
//using System.Text;
//using System.Threading.Tasks;


//namespace The3BlackBro.WebQueue.Api.Controllers.Auth
//{
//    [Route("auth")]
//    public class AuthController : Controller {
//        private readonly IUserService _service;
//        private readonly AppSettingsOptions _appSettingsOptions;
//        private readonly UserManager<User> _userManager;

//        public AuthController(IUserService service, IOptions<AppSettingsOptions> appSettings, UserManager<User> userManager) {
//            _service = service;
//            _appSettingsOptions = appSettings.Value;
//            _userManager = userManager;
//        }
//        /// <summary>
//        /// Endpoint de cadastro de usuário
//        /// </summary>
//        [HttpPost("register")]
//        public async Task<IActionResult> Create([FromBody] RegisterDto regDto) {
//            var command = new NewUserCommand() {
//                Email = regDto.Email,
//                Cpf = regDto.Cpf,
//                Password = regDto.Password
//            };

//            var ret = await _service.Create(command);

//            if (!ret.Valid)
//                return BadRequest(ret.Message);

//            return Ok(ret);
//        }
//        /// <summary>
//        /// Endpoint de login de usuário
//        /// </summary>
//        [HttpPost("login")]
//        public async Task<IActionResult> LoginA([FromBody] LoginDto loginDto) {
//            var command = new LoginCommand() {
//                Email = loginDto.Email,
//                Password = loginDto.Password
//            };

//            var ret = await _service.Login(command);

//            if (!ret.Valid)
//                return BadRequest(ret.Message);

//            var jwt = await BuildJWT(loginDto.Email);
//            return Ok(new CommandResult(true, jwt, ret.Data));
              
//        }

//        private async Task<string> BuildJWT(string email) {

//            User user = await _userManager.FindByEmailAsync(email);
//            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
//            byte[] key = Encoding.ASCII.GetBytes(_appSettingsOptions.Secret);

//            var tokenDescriptor = new SecurityTokenDescriptor {

//                Issuer = _appSettingsOptions.Issuer,
//                Audience = _appSettingsOptions.ValidIn,
//                Expires = DateTime.UtcNow.AddHours(_appSettingsOptions.ExpirationHours),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
//        }
//    }
//}
