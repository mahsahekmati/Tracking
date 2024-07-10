using Faradid.Tracking.Application.Interfaces;
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

        public async Task<Users> GetUserByBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                return null;
            }
            var userBarcode= await _trackingDbContext.UsersBarcodes.FirstOrDefaultAsync(x => x.Barcode == barcode && x.IsUse==false);
            if (userBarcode == null)
            {
                return null;
            }
            return await _trackingDbContext.Users.SingleOrDefaultAsync(a=>a.Id == userBarcode.UserId);
        }

    }
}
