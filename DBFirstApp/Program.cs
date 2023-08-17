using Microsoft.EntityFrameworkCore;

namespace DBFirstApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (HelloappdbContext db = new HelloappdbContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Object list:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}