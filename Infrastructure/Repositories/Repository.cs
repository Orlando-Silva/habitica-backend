using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext { get; set; }

        protected DbSet<T>  DbSet { get; set; }

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public T Add(T entity) => DbSet.Add(entity).Entity;

        public void Add(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public IEnumerable<T> GetAllBy(Expression<Func<T, bool>> predicate) => DbSet.Where(predicate);

        public T GetBy(Expression<Func<T, bool>> predicate) => DbSet.First(predicate);

        public T GetById(int id) => DbSet.Find(id) ?? throw new InvalidOperationException();
    }
}
