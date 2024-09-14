using Faradid.Tracking.Application.Interfaces.Repository;
using Faradid.Tracking.Domain.Entities.ApiResult;
using Faradid.Tracking.Domain.Entities.Users;
using Faradid.Tracking.MVC.Services.AuthenticateService;
using Faradid.Tracking.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace Faradid.Tracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        //[HttpGet("{username}/{password}")]
        //public async Task<ActionResult<ApiResult>> UserAutentication(string username, byte[] password)
        //{
        //    if (!string.IsNullOrEmpty(username) && password != null)
        //    {
        //        var decodepassword = Faradid.Tracking.Identity.Constanse.PasswordHelper.DecryptStringFromBytes_Aes(password);
        //        var isLoggedIn = await _authenticateService.Authenticate(username, decodepassword);
        //        if (isLoggedIn)
        //        {
        //            ApiResult apiResult = new ApiResult();
        //            apiResult.Result = isLoggedIn;
        //            apiResult.IsSuccess = true;
        //            apiResult.StatusCode = HttpStatusCode.OK;
        //            return Ok(apiResult);
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }


        //    return NotFound();
        //}

        [HttpGet("{barcode}")]
        public async Task<ActionResult<ApiResult>> GetUserInfoByBarcode(string barcode)
        {

            ApiResult apiResult = new ApiResult();
            apiResult.ErrorMessages=new List<string>();
            if (!string.IsNullOrEmpty(barcode))
            {
                var userbarcode = await _userRepository.FindUserBarcode(barcode);
                if(userbarcode != null)
                {
                    if (!userbarcode.IsUse)
                    {
                        var user = await _userRepository.GetById(userbarcode.UserId);
                        if (user != null)
                        {
                            apiResult.Result = user;
                            apiResult.IsSuccess = true;
                            apiResult.StatusCode = HttpStatusCode.OK;
                            return Ok(apiResult);
                        }
                        else
                        {
                            apiResult.IsSuccess = false;
                            apiResult.StatusCode = HttpStatusCode.BadRequest;
                            apiResult.ErrorMessages.Add("کاربر یافت نشد");
                            apiResult.Result = null;
                            return BadRequest(apiResult);
                        }

                    }
                    else
                    {
                        apiResult.IsSuccess = false;
                        apiResult.StatusCode = HttpStatusCode.BadRequest;
                        apiResult.ErrorMessages.Add("بارکد استفاده شده");
                        apiResult.Result = null;
                        return BadRequest(apiResult);
                    }
                   

                }
                else
                {
                    apiResult.IsSuccess = false;
                    apiResult.StatusCode=HttpStatusCode.BadRequest;
                    apiResult.ErrorMessages.Add( "بارکد یافت نشد");
                    apiResult.Result = null;
                    return NotFound(apiResult);
                }
            }
            apiResult.IsSuccess = false;
            apiResult.StatusCode = HttpStatusCode.NotFound;
            apiResult.ErrorMessages.Add("بارکد خالی است");
            apiResult.Result = null;
            return NotFound(apiResult);

        }


    }
}
