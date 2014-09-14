namespace AlbumSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class AlbumModel
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }
    }
}