//using PhonesLib; - для json
using PhonesLibSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phones.Controllers
{
    public class DictController : Controller
    {
        IPhoneDictionary<Contact> phones = null;
        public DictController(IPhoneDictionary<Contact> phones)
        {
            this.phones = phones;
        }

        // GET: Dict
        public ActionResult Index()
        {
            List<Contact> contacts = phones.GetConList();
            return View(contacts);
        }

        // GET: Dict/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Dict/AddSave
        [HttpPost]
        public ActionResult AddSave(FormCollection collection)
        {
            try
            {
                string surname = Convert.ToString(collection["Surname"]);
                string phone = Convert.ToString(collection["Phone"]);
                var contacts = phones.GetConList();
                var maxId = contacts.Max(p => p.Id);
                Contact contact = new Contact() { Id = maxId + 1, Surname = surname, Phone = phone };
                phones.Create(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Dict/Update/Id
        public ActionResult Update(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var contacts = phones.GetConList();
                var contact = contacts.Where(p => p.Id.Equals(id)).FirstOrDefault();
                return View(contact);
            }
        }

        // POST: Dict/UpdateSave
        [HttpPost]
        public ActionResult UpdateSave(FormCollection collection)
        {
            try
            {
                string surname = Convert.ToString(collection["Surname"]);
                string phone = Convert.ToString(collection["Phone"]);
                long id = Convert.ToInt64(collection["Id"]);
                Contact updatedContact = new Contact() { Id = id, Phone = phone, Surname = surname };
                phones.Update(updatedContact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dict/Delete/name
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var contacts = phones.GetConList();
                var contact = contacts.Where(p => p.Id.Equals(id)).FirstOrDefault();
                return View(contact);
            }
        }

        // POST: Dict/DeleteSave
        [HttpPost]
        public ActionResult DeleteSave(FormCollection collection)
        {
            try
            {
                long id = Convert.ToInt64(collection["Id"]);
                phones.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Partial(Contact item)
        {
            ViewBag.Message = "Это частичное представление.";
            return PartialView(item);
        }
    }
}