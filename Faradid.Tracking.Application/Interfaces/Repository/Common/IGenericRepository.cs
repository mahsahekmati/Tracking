using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Application.Interfaces.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(object id);
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> Exist(object id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
