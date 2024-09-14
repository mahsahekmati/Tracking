using Faradid.Tracking.Application.Interfaces.Repository.Common;
using Faradid.Tracking.Domain.Entities.Users;

namespace Faradid.Tracking.Application.Interfaces.Repository
{
    public interface IUserRepository:IGenericRepository<Users>
    {

       Task< UsersBarcode> FindUserBarcode(string barcode);
  
    }
}
