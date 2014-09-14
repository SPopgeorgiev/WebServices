namespace AlbumSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Artist
    {
        private ICollection<Song> songs;
        private ICollection<Album> albums;

        public Artist()
        {
            this.songs = new HashSet<Song>();
            this.albums = new HashSet<Album>();
        }
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }
            set
            {
                this.songs = value;
            }
        }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }
    }
}
