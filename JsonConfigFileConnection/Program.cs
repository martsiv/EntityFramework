using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test; //Залежності від іншого проекту, щоб підтягнути клас User

namespace JsonConfigFileConnection
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------   Using json config file
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("MyDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                var users = db.Users.ToList();
                foreach (User user in users)
                    Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
            }
        }
    }
}