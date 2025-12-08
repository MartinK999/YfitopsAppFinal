using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops.Repositories
{
    public interface ITrackRepository
    {
        Track GetById(int id);
        IEnumerable<Track> GetByAlbumId(int? albumId);
        IEnumerable<Track> GetAll();
        IEnumerable<Track> GetByUserId(int userId); 
        void Add(Track track);
        void Update(Track track);
        void Delete(Track track);
    }
}
