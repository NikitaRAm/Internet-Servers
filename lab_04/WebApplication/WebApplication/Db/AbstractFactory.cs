using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication.Db
{
    public abstract class AbstractFactory<T, K>
    {
        public abstract List<T> GetAll();
        public abstract T GetOneById(K id);
        public abstract void Update(T entity);
        public abstract bool Delete(K id);
        public abstract void Create(T entity);
    }
}