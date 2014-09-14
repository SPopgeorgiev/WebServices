namespace AlbumSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using AlbumSystem.Models;
    public class SongModel
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public virtual Album Album { get; set; }

        public int ArtistId { get; set; }
    }
}