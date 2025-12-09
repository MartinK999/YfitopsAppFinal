using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yfitops.Models.Entities;

namespace Yfitops
{

    public class MusicContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
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
        public MusicContext() : base()
        {
            this.Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.Entity<Track>()
                .HasOne(t => t.Album)
                .WithMany(a => a.Tracks)
                .HasForeignKey(t => t.AlbumId)
                .IsRequired(false)             
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
