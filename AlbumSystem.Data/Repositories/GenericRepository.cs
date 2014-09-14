namespace AlbumSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IAlbumSystemDBContext context;
        private IDbSet<T> set;

        public GenericRepository()
        {
            this.context = new AlbumSystemDbContext();
            this.set = context.Set<T>();
        }
        public GenericRepository(IAlbumSystemDBContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> SelectAll()
        {
            return this.context.Set<T>();
        }

        public System.Linq.IQueryable<T> Find(Expression<Func<T, bool>> conditions)
        {
            return this.SelectAll().Where(conditions);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        private void ChangeState(T entity, EntityState state)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = state;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
