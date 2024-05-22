using System.Linq.Expressions;
using Bootcamp.Domain;
using Bootcamp.Service;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.Repository
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>
        where T : BaseEntity<int>
    {
        public DbSet<T> DbSet { get; set; } = context.Set<T>();
        protected AppDbContext Context = context;

        public async Task<T> Create(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public async Task Update(T entity)
        {
            await Task.Run(() => DbSet.Update(entity));
        }

        public async Task Delete(int id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity!); //entity null kontrolü serviste yapılıyor. bu katmana gelmişse null olamaz
        }

        public async Task<T?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            var list = await DbSet.ToListAsync();
            return list.AsReadOnly();
        }

        public async Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            var list = await DbSet.Where(predicate).ToListAsync();
            return list.AsReadOnly();
        }

        public async Task<bool> HasExist(int id)
        {
            return await DbSet.AnyAsync(x => x.Id == id);
        }
    }
}
