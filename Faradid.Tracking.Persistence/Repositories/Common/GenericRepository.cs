using Faradid.Tracking.Application.Interfaces.Common;
using Faradid.Tracking.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TrackingDbContext _trackingDbContext;
        public GenericRepository(TrackingDbContext trackingDbContext)
        {
            trackingDbContext=_trackingDbContext;
        }
        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {

            throw new NotImplementedException();
        }


        public Task<T> Gets(int id)
        {
            throw new NotImplementedException();
        }


        public Task<IReadOnlyList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(object id)
        {
            throw new NotImplementedException();
        }
    }
}
