using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicContext _context;

        public ArtistRepository(MusicContext context)
        {
            _context = context;
        }
        public void Add(Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
        }

        public void Delete(Artist artist)
        {
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }

        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }

        public Artist GetByArtistName(string name)
        {
            return _context.Artists.FirstOrDefault(a => a.Name == name);
        }

        public Artist GetById(int id)
        {
            return _context.Artists.Find(id);
        }

        public void Update(Artist artist)
        {
            _context.Artists.Update(artist);
            _context.SaveChanges();
        }
    }
}
