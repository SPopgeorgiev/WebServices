
namespace AlbumSystem.Data
{
    using AlbumSystem.Data.Repositories;
    using AlbumSystem.Models;
    public interface IAlbumSystemData
    {
        IGenericRepository<Artist> Artist { get; }

        IGenericRepository<Song> Songs { get; }

        IGenericRepository<Album> Albums { get; }

        void SaveChanges();
    }
}
