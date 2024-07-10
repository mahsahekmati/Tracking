using Faradid.Tracking.MVC.ViewModels;

namespace Faradid.Tracking.MVC.Services.AuthenticateService
{
    public interface IAuthenticateService
    {

        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterViewModel register);
        Task Logout();
    }
}
