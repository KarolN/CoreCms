using System;
using System.Linq;
using System.Threading.Tasks;
using CoreCms.Cms.Model.Base;

namespace CoreCms.DataAccess.Contract
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetQueryable();

        Guid Insert(T entity);

        void Update(T entity);

        void Remove(Guid id);

        Task<Guid> InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(Guid id);
    }
}