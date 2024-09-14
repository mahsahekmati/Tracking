using Faradid.Tracking.Application.Interfaces.Repository;
using Faradid.Tracking.Domain.Entities.Users;
using Faradid.Tracking.Persistence.Context;
using Faradid.Tracking.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly TrackingDbContext _trackingDbContext;
        public UserRepository(TrackingDbContext trackingDbContext):base(trackingDbContext)
        {
            _trackingDbContext = trackingDbContext;
        }
        //این تابع چک میکند بارکد وجود دارد یا نه
        public async Task<UsersBarcode> FindUserBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                return null;
            }
            var userBarcode = await _trackingDbContext.UsersBarcodes.FirstOrDefaultAsync(x => x.Barcode == barcode);
            if (userBarcode == null)
            {
                return null;
            }
            return userBarcode;
        }



    }
}
