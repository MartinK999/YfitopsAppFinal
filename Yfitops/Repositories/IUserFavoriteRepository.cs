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

        IEnumerable<UserFavorite> GetAll();
        IEnumerable<UserFavorite> GetByUserId(int userId);
        IEnumerable<UserFavorite> GetFavoritesByType(int favoriteId, string favoriteType);

        bool Exists(int userId, string favoriteType, int favoriteId);

        void Add(UserFavorite favorite);
        void Update(UserFavorite favorite);
        void Delete(UserFavorite favorite);
    }
}
