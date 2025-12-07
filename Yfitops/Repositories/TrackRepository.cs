using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly MusicContext _context;
        public TrackRepository(MusicContext context)
        {
            _context = context;
        }
        public void Add(Track track)
        {
            _context.Tracks.Add(track);
            _context.SaveChanges();
        }

        public void Delete(Track track)
        {
            _context.Tracks.Remove(track);
            _context.SaveChanges();
        }

        public IEnumerable<Track> GetAll()
        {
            return _context.Tracks.ToList();
        }

        public IEnumerable<Track> GetByAlbumId(int albumId)
        {
            return _context.Tracks.Where(t => t.AlbumId == albumId).ToList();
        }

        public Track GetById(int id)
        {
            return _context.Tracks.Find(id);
        }

        public void Update(Track track)
        {
            _context.Tracks.Update(track);
            _context.SaveChanges();
        }
    }
}
