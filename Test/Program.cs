using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    User tom = new User { Name = "Tom", Age = 33 };
            //    User alice = new User { Name = "Alice", Age = 26 };
            //    //Add to db
            //    db.Users.Add(tom);
            //    db.Users.Add(alice);
            //    //or
            //    //db.AddRange(tom, alice);

            //    db.SaveChanges();
            //    Console.WriteLine("Objects saved successfully!");
            //    //Get from db
            //    var users = db.Users.ToList();
            //    Console.WriteLine("Object list:");
            //    foreach (User u in users) 
            //    {
            //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            //    }

            //}


            // ----------------------------------------------
            // Adding
            using (ApplicationContext db = new ApplicationContext())
            {
                User tom = new User { Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };

                // Adding
                db.Users.Add(tom);
                db.Users.Add(alice);
                db.SaveChanges();
            }

            // Getting
            using (ApplicationContext db = new ApplicationContext())
            {
                // Get entities from db and show in console
                var users = db.Users.ToList();
                Console.WriteLine("Data after adding:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Editing
            using (ApplicationContext db = new ApplicationContext())
            {
                // Get first entity
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    //Updating entity
                    //db.Users.Update(user);
                    db.SaveChanges();
                }
                // Show data after updating
                Console.WriteLine("\nData after editing:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Deliting
            using (ApplicationContext db = new ApplicationContext())
            {
                // Get first entity
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    //Deleting entity
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                // Show data after updating
                Console.WriteLine("\nData after deleting:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

        }
    }
}