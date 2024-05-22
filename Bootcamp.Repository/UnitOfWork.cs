using Bootcamp.Service;

namespace Bootcamp.Repository
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<int> CommitAsync()
        {
           return await context.SaveChangesAsync();
        }
    }
}
