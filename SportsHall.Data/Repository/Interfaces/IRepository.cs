namespace SportsHall.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);
        Task<TType> GetByIdAsync(TId id);
        IEnumerable<TType> GetAll();
        Task<IEnumerable<TType>> GetAllAsync();
        IQueryable<TType> GetAllAttached();
        void Add(TType item);
        Task AddAsync(TType item);
        bool Delete(TType entity);
        Task<bool> DeleteAsync(TType entity);
        bool Update(TType item);
        Task<bool> UpdateAsync(TType item);



    }
}
