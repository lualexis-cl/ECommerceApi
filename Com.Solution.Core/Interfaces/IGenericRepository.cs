using Com.Solution.Core.Entities;
using Com.Solution.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Com.Solution.Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllListAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> expression = null,
            params Expression<Func<T, object>>[] includes);
    }
}
