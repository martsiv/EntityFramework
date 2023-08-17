using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Add_Ignored_properties
{
    //[NotMapped]     //Замість Fluent API (викликати в ApplicationContext -> OnModelCreating() -> modelBuilder.Ignore<Company>();)
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
