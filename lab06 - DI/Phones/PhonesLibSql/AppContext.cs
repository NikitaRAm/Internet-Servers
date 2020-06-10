using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesLibSql
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("DBConnection")
        { }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
