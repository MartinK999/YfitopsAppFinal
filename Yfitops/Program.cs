using Yfitops.Models.Entities;

namespace Yfitops
{
    internal static class Program
    {
  
        [STAThread]
        static void Main()
        {
            

            using (var context = new MusicContext())
            {
                
                context.Users.Add(new User {Username = "admin", Password = "testPassword", Role = "Admin" });
                context.SaveChanges();

            
                var users = context.Users.ToList();
                foreach (var u in users)
                {
                    Console.WriteLine($"User: {u.Username}, Role: {u.Role}");
                }
            }


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}