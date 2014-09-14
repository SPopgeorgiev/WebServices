namespace AlbumSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AlbumSystem.Data.Repositories;
    using AlbumSystem.Models;
    public class AlbumSystemData : IAlbumSystemData
    {
        private IAlbumSystemDBContext context;
        private Dictionary<Type, object> repositories;

        public AlbumSystemData()
            : this(new AlbumSystemDbContext())
        {

        }

        public AlbumSystemData(IAlbumSystemDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Artist> Artist
        {
            get 
            {
                return this.GetRepository<Artist>();
            }
        }

        public IGenericRepository<Song> Songs
        {
            get 
            { 
                return this.GetRepository<Song>(); 
            }
        }

        public IGenericRepository<Album> Albums
        {
            get 
            { 
                return this.GetRepository<Album>();
            }
        }
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
