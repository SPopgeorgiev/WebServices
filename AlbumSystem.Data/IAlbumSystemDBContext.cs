
namespace AlbumSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using AlbumSystem.Models;
    public interface IAlbumSystemDBContext
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
