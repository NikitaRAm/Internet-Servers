using System;
using System.Data.Entity;

namespace ASP.NET.MVC.CRUD.Models
{ 
    public class NumbersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        
    }

    public class NumbersContext : DbContext
    {
        public DbSet<NumbersModel> Numbers { get; set; }
    }
}