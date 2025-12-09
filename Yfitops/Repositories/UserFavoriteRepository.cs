using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops.Repositories
{
    public class UserFavoriteRepository : IUserFavoriteRepository
    {
        private readonly MusicContext _context;
        public UserFavoriteRepository(MusicContext context)
        {
            _context = context;
        }
        public void Add(UserFavorite favorite)
        {
            _context.UserFavorites.Add(favorite);
            _context.SaveChanges();
        }

        public void Delete(UserFavorite favorite)
        {
            _context.UserFavorites.Remove(favorite);
            _context.SaveChanges();
        }

        public bool Exists(int userId, string favoriteType, int favoriteId)
        {
            return _context.UserFavorites.Any(uf => uf.UserId == userId && uf.FavoriteType == favoriteType && uf.FavoriteId == favoriteId);
        }

        public IEnumerable<UserFavorite> GetAll()
        {
            return _context.UserFavorites.ToList();
        }

        public UserFavorite GetById(int id)
        {
            return _context.UserFavorites.Find(id);
        }

        public IEnumerable<UserFavorite> GetByUserId(int userId)
        {
            return _context.UserFavorites.Where(uf => uf.UserId == userId).ToList();
        }

        public IEnumerable<UserFavorite> GetFavoritesByType(int favoriteId, string favoriteType)
        {
            return _context.UserFavorites
                .Where(uf => uf.FavoriteId == favoriteId && uf.FavoriteType == favoriteType)
                .ToList();
        }

        public void Update(UserFavorite favorite)
        {
            _context.UserFavorites.Update(favorite);
        }
    }
}
