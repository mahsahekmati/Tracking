using Faradid.Tracking.Application.Interfaces.Common;
using Faradid.Tracking.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Application.Interfaces
{
    public interface IUserRepository:IGenericRepository<Users>
    {
       Task< Users> GetUserByBarcode(string barcode);
  
    }
}
