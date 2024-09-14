using Faradid.Tracking.Domain.Entities.ApiResult;
using Faradid.Tracking.MVC.ViewModels;

namespace Faradid.Tracking.MVC.Services.AuthenticateService
{
    public interface IAuthenticateService
    {

        Task<ApiResult> Authenticate(string email, string password);
        Task<ApiResult> Register(RegisterViewModel register);
        Task Logout();
    }
}
