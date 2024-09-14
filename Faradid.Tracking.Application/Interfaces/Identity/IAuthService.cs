using Faradid.Tracking.Domain.Entities.ApiResult;
using Faradid.Tracking.Identity.Models;

namespace Faradid.Tracking.Interfaces.Identity
{
    public interface IAuthService
    {
        Task<ApiResult> Login(AuthRequest request);
        Task<ApiResult> Register(RegisterationRequest request);
    }
}
