using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yfitops.Models.Entities
{
    public class UserFavorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string FavoriteType { get; set; }   // Artist / Album / Track
        public int FavoriteId { get; set; }

        public User User { get; set; }
    }
}
