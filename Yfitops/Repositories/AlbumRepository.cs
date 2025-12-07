using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicContext _context;
        public AlbumRepository(MusicContext context)
        {
            _context = context;
        }
        public void Add(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public void Delete(Album album)
        {
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums.ToList();
        }

        public IEnumerable<Album> GetByArtistId(int artistId)
        {
            return _context.Albums.Where(a => a.ArtistId == artistId).ToList();
        }

        public Album GetById(int id)
        {
            return _context.Albums.Find(id);
        }

        public void Update(Album album)
        {
            _context.Albums.Update(album);
            _context.SaveChanges();
        }
    }
}
