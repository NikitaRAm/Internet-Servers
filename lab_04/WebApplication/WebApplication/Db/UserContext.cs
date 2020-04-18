using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Db
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}