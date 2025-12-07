using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yfitops.Models.Entities;

namespace Yfitops
{

    public class MusicContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var projectPath = AppDomain.CurrentDomain.BaseDirectory; 
            var databasePath = Path.Combine(projectPath, @"..\..\..\music.db"); 
            databasePath = Path.GetFullPath(databasePath);

            options.UseSqlite($"Data Source={databasePath}");
        }
    }
}
