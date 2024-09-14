using Faradid.Tracking.MVC.Services.AuthenticateService;
using Faradid.Tracking.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Faradid.Tracking.MVC.Controllers
{
    public class UsersController : Controller
    {
        private IAuthenticateService _authenticateService;
        public UsersController(IAuthenticateService authenticateService)
        {
            this._authenticateService = authenticateService;
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {

                return View(register);
            }

            var response = await _authenticateService.Register(register);
            if (response != null) 
            {
                if (response.IsSuccess)
                {
                    return LocalRedirect("/");
                }
            }

            ModelState.AddModelError("", response.ErrorMessages.FirstOrDefault());
            return View(register);
        }
        #endregion


        #region Login
        public IActionResult Login(string returnUrl=null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            var response = await _authenticateService.Authenticate(login.Email, login.Passsword);
            if (response!=null)
            {
                if (response.IsSuccess)
                {
                return LocalRedirect(returnUrl);
                }
            }

            ModelState.AddModelError("", response.ErrorMessages.FirstOrDefault());
            return View(login);
        }
        #endregion


        #region Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authenticateService.Logout();
            return LocalRedirect("/Users/Login");
        }
        #endregion
    }
}
