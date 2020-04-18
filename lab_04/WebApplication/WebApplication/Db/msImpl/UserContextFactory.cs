using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Db;
using WebApplication.Models;

namespace WebApplication.Db.msImpl
{
    public class UserContextFactory : AbstractFactory<User, long>
    {
        private static UserContext userContext = new UserContext();
        
        public override void Create(User entity)
        {
            userContext.Users.Add(entity);
            userContext.SaveChanges();
        }

        public override bool Delete(long id)
        {
            User user = userContext.Users.Find(id);
            if(user != null)
            {
                userContext.Users.Remove(user);
                userContext.SaveChanges();
                return true;
            }
            return false;
        }

        public override List<User> GetAll()
        {
            return userContext.Users.ToList();
        }

        public override User GetOneById(long id)
        {
            return userContext.Users.Find(id);
        }

        public override void Update(User entity)
        {
            foreach (User user in userContext.Users)
            {
                if (user.Id == entity.Id)
                {
                    user.Name = entity.Name;
                    user.PhoneNumber = entity.PhoneNumber;
                }                    
            }
            
            userContext.SaveChanges();
        }
    }
}