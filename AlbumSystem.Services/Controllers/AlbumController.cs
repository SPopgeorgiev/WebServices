namespace AlbumSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using AlbumSystem.Data;
    using AlbumSystem.Services.Models;
    using AlbumSystem.Models;

    public class AlbumController : ApiController
    {
        private IAlbumSystemData data;

        public AlbumController()
            : this(new AlbumSystemData())
        {
        }

        public AlbumController(IAlbumSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            var album = this.data.Albums.SelectAll().FirstOrDefault(a => a.AlbumId == id);

            return Ok(album);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data.Albums.SelectAll().ToList();

            return Ok(albums);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.Albums.Add(new Album
            {
                Producer = album.Producer,
                Title = album.Title,
                Year = album.Year
            });

            this.data.SaveChanges();

            return Ok(HttpStatusCode.Created);
        }
      
        [HttpPut]
        public IHttpActionResult AddSong(int idAlbum, int idSong)
        {
            var existingSong = this.data.Songs.SelectAll().FirstOrDefault(a => a.SongId == idSong);
            var existingAlbum = this.data.Albums.SelectAll().FirstOrDefault(a => a.AlbumId == idAlbum);

            if (existingSong == null)
            {
                return BadRequest("No such song with this id!");
            }

            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Songs.Add(existingSong);
           
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }
      

        [HttpPut]
        public IHttpActionResult RemoveSong(int idAlbum, int idSong)
        {
            var existingSong = this.data.Songs.SelectAll().FirstOrDefault(a => a.SongId == idSong);
            var existingAlbum = this.data.Albums.SelectAll().FirstOrDefault(a => a.AlbumId == idAlbum);

            if (existingSong == null)
            {
                return BadRequest("No such song with this id!");
            }

            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Songs.Remove(existingSong);

            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }
     
        [HttpPut]
        public IHttpActionResult AddArtist(int idAlbum, int idArtist)
        {
            var existingArtist = this.data.Artist.SelectAll().FirstOrDefault(a => a.ArtistId == idArtist);
            var existingAlbum = this.data.Albums.SelectAll().FirstOrDefault(a => a.AlbumId == idAlbum);

            if (existingArtist == null)
            {
                return BadRequest("No such artist with this id!");
            }

            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Artists.Add(existingArtist);
          
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult RemoveArtist(int idAlbum, int idArtist)
        {
            var existingArtist = this.data.Artist.SelectAll().FirstOrDefault(a => a.ArtistId == idArtist);
            var existingAlbum = this.data.Albums.SelectAll().FirstOrDefault(a => a.AlbumId == idAlbum);

            if (existingArtist == null)
            {
                return BadRequest("No such artist with this id!");
            }

            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Artists.Remove(existingArtist);

            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }
        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            var existingSong = this.data.Songs.SelectAll().FirstOrDefault(a => a.SongId == id);

            if (existingSong == null)
            {
                return BadRequest("No such song with this id!");
            }

            existingSong.Title = (song.Title != null) ? song.Title : existingSong.Title;
            existingSong.Genre = (song.Genre != null) ? song.Genre : existingSong.Genre;
            existingSong.Year = (song.Year != 0) ? song.Year : existingSong.Year;

            this.data.Songs.Update(existingSong);
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = this.data.Albums.SelectAll().FirstOrDefault(a => a.AlbumId == id);

            if (album == null)
            {
                return BadRequest("No such artist with this id!");
            }
            this.data.Albums.Delete(album);

            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }
    }
}
