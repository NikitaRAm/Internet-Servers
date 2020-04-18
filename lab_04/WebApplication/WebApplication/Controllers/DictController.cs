using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Db.jsonImpl;
using WebApplication.Db.msImpl;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DictController : Controller
    {
        private UserContextFactory userFactory = new UserContextFactory();

        // GET: Dict
        public ActionResult Index()
        {
            List<User> users = userFactory.GetAll();
            users.Sort((u1, u2) => u1.Name.CompareTo(u2.Name));
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            userFactory.Create(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(long? Id)
        {
            if (Id != null)
                return View(userFactory.GetOneById((int)Id.Value));
            else
                return RedirectToAction("Index");
        }

        public ActionResult Update([Bind(Include ="Id,Name,PhoneNumber")] User user)
        {
            userFactory.Update(user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete (long? Id)
        {
            userFactory.Delete((int)Id.Value);
            return RedirectToAction("Index");
        }

        
    }
}