namespace AlbumSystem.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    public interface IGenericRepository<T>
    {
        IQueryable<T> SelectAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
