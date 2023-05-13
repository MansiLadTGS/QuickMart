using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Middleware.Auth;

namespace QuickMart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IJWTAuthManager _authManager;
        private readonly IWebHostEnvironment _environment;
        public LoginController(ILogger<LoginController> logger, IJWTAuthManager authManager, IWebHostEnvironment environment)
        {
            _logger = logger;
            _authManager = authManager;
            _environment = environment;
        }
    }
}
