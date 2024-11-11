using Microsoft.EntityFrameworkCore;
using SportsHall.Data.Repository.Interfaces;
using System.Formats.Tar;

namespace SportsHall.Data.Repository
{
    public class BaseRepository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly SportsHallDbContext dbContext;
        private readonly DbSet<TType> dbSet;
        public BaseRepository(SportsHallDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TType>();
        }
        public void Add(TType item)
        {
            this.dbSet.Add(item);
            this.dbContext.SaveChanges();
        }

        public async Task AddAsync(TType item)
        {
            await this.dbSet.AddAsync(item);
            await this.dbContext.SaveChangesAsync();
        }

        public bool Delete(TType entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TType entity)
        {
            this.dbSet.Remove(entity);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<TType> GetAll()
        {
            return this.dbSet.ToArray();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await this.dbSet.ToArrayAsync();
        }

        public IQueryable<TType> GetAllAttached()
        {
            return this.dbSet.AsQueryable();
        }

        public TType GetById(TId id)
        {
            TType entity = this.dbSet
                .Find(id);

            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType entity = await this.dbSet
                .FindAsync(id);

            return entity;
        }
        public bool Update(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.dbContext.Entry(item).State = EntityState.Modified;
                this.dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.dbContext.Entry(item).State = EntityState.Modified;
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
