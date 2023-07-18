using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CompletedTaskRepository : Repository<CompletedTask>, ICompletedTaskRepository
    {
        public CompletedTaskRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
