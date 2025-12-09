using Microsoft.Extensions.DependencyInjection;
using Yfitops.Forms;
using Yfitops.Models.Entities;
using Yfitops.Repositories;

namespace Yfitops
{
    internal static class Program
    {
       
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {   
            var services = new ServiceCollection();

            services.AddDbContext<MusicContext>();

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserFavoriteRepository, UserFavoriteRepository>();

            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<RegistrationForm>();
            services.AddTransient<FavoritesForm>();

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
        }
    }
}