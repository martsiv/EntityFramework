using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _05_Add_Ignored_properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            //Встановлюємо шлях до поточного каталогу якщо це SqlLite
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //отримуємо конфігурацію з json
            builder.AddJsonFile("appsettings.json");
            //створюємо конфігурацію
            var config = builder.Build();
            //отримуємо рядок підключення
            string connectionString = config.GetConnectionString("MyDbConnection");

            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionBuilder.UseSqlServer(connectionString).Options;

            //using (ApplicationContext db = new ApplicationContext(options))
            //{
            //    //db.Database.EnsureDeleted();
            //    //db.Database.EnsureCreated();
            //    // создаем два объекта User
            //    if (db.Database.CanConnect())
            //    {
            //        User user1 = new User { Name = "Tom", Age = 33 };
            //        User user2 = new User { Name = "Alice", Age = 26 };

            //        // добавляем их в бд
            //        db.Users.AddRange(user1, user2);
            //        db.SaveChanges();
            //    }
            //}
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var users = db.Users.ToList();
                foreach (var u in users)
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");

            }
        }
    }
}