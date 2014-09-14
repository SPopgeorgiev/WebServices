namespace AlbumSystem.Data
{

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using AlbumSystem.Models;
    using AlbumSystem.Data.Migrations;
    public class AlbumSystemDbContext : DbContext, IAlbumSystemDBContext
    {
        public AlbumSystemDbContext()
            : base("AlbumSystemDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlbumSystemDbContext, Configuration>());
        }
        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Song> Songs { get; set; }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Artist>().HasRequired(p => p.Song).WithOptional();
        //}
    }
}
