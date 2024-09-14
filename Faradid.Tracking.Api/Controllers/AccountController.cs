using Faradid.Tracking.Domain.Entities.ApiResult;
using Faradid.Tracking.Interfaces.Identity;
using Faradid.Tracking.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faradid.Tracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResult>> Login(AuthRequest request)
        {
            return Ok(await authService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResult>> Register(RegisterationRequest request)
        {
            return Ok(await authService.Register(request));
        }
    }
}
