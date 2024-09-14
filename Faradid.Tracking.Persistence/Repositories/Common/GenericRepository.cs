using Faradid.Tracking.Application.Interfaces.Repository.Common;
using Faradid.Tracking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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
       private DbSet<T> _dbSet;
        public GenericRepository(TrackingDbContext trackingDbContext)
        {
            this._trackingDbContext = trackingDbContext;
        }
        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {

            throw new NotImplementedException();
        }


        public async Task<T> GetById(int id)
        {
            var a = _trackingDbContext.Set<T>();
            return await _trackingDbContext.Set<T>().FindAsync(id);
        }


        public Task<IReadOnlyList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(object id)
        {
           return await _trackingDbContext.Set<T>().FindAsync(id);
        }

        public Task<bool> Exist(object id)
        {
            throw new NotImplementedException();
        }
    }
}
