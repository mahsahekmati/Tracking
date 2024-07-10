using Faradid.Tracking.Application.Interfaces;
using Faradid.Tracking.Domain.Entities.ApiResult;
using Faradid.Tracking.Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Faradid.Tracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }
        [HttpGet]
        public async Task<ActionResult<Users>> GetUserInfoByBarcode(string barcode)
        {
            if(!string.IsNullOrEmpty(barcode))
            {

                var result = await _userRepository.GetUserByBarcode(barcode);
                if(result != null)
                {
                    ApiResult apiResult = new ApiResult();
                    apiResult.Result = result;
                    apiResult.IsSuccess = true;
                    apiResult.StatusCode=HttpStatusCode.OK;
                return Ok(apiResult);
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();

        }

    }
}
