using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops.Repositories
{
    public interface IUserFavoriteRepository
    {
        UserFavorite GetById(int id);
        IEnumerable<UserFavorite> GetByUserId(int userId);
        void Add(UserFavorite favorite);
        void Update(UserFavorite favorite);
        void Delete(UserFavorite favorite);
    }
}
