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

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<RegistrationForm>();

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
        }
    }
}