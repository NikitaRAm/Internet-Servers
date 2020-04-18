using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication.Db;
using WebApplication.Models;

namespace WebApplication.Db.jsonImpl
{
    public class UserFactory : AbstractFactory<User, int>
    {
        //private static string fileName = "G:\\LEARN\\6 сем\\ПИС(ASP.NET)\\labs\new\\lab_03\\WebApplication\\WebApplication\\users.json";
        //private static string fileName = "G:\\users.json";
        private static string fileName = "E:\\Education\\Programming_Internet-Servers\\Labs\\Internet-Servers\\lab_04\\WebApplication\\WebApplication\\users.json";

        public override void Create(User entity)
        {
            List<User> users = GetAll();
            int lastId = users.Last().Id;
            entity.Id = lastId+1;
            users.Add(entity);
            Save(users);
        }

        public override bool Delete(int id)
        {
            List<User> users = GetAll().Where(p => p.Id != id).ToList();
            Save(users);
            return true;
        }

        public override List<User> GetAll()
        {
            string jsonText = "";
            using (StreamReader reader= new StreamReader(fileName))
            {
                jsonText = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<User>>(jsonText);
        }

        public override User GetOneById(int id)
        {
            return GetAll().Where(p => p.Id == id).First();
        }

        public override void Update(User entity)
        {
            List<User> users = GetAll();
            foreach(User u in users)
            {
                if(u.Id == entity.Id)
                {
                    u.Name = entity.Name;
                    u.PhoneNumber = entity.PhoneNumber;
                }
            }
            Save(users);
        }

        public void Save(List<User> users)
        {
            string jsonText = JsonConvert.SerializeObject(users, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(fileName, false, System.Text.Encoding.Default))
            {
                writer.Write(jsonText);
            }
        }
    }
}