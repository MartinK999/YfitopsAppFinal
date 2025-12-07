using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops.Repositories
{
    public interface IAlbumRepository
    {
        Album GetById(int id);
        IEnumerable<Album> GetByArtistId(int artistId);
        IEnumerable<Album> GetAll();
        void Add(Album album);
        void Update(Album album);
        void Delete(Album album);
    }
}
