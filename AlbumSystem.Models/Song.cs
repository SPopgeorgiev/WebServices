namespace AlbumSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Song
    {
        private ICollection<Album> albums;

        public Song()
        {
            this.albums = new HashSet<Album>();
        }
        public int SongId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
