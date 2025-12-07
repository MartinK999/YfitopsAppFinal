using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops.Repositories
{
    public interface IArtistRepository
    {
        Artist GetById(int id);
        Artist GetByArtistName(string name);
        IEnumerable<Artist> GetAll();
        void Add(Artist artist);
        void Update(Artist artist);
        void Delete(Artist artist);
    }
}
