

using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Add(IEnumerable<T> entities);

        T GetById(int id);

        T GetBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAllBy(Expression<Func<T, bool>> predicate);
    }
}
