using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Filters;

namespace WebApplication.Controllers
{
    public class AResearchController : Controller
    {
        // GET: AResearch
        public ActionResult Index()
        {
            return View();
        }

        [MyActionFilter]
        [MyResultFilter]
        [MyExceptionFilter]
        public ActionResult AA(int? id)
        {
            Response.Write("<div class=\"container\"><h2>Action AA: (id = " + id.Value + ")</h2></div>");
            return View("Index");
        }

        [MyActionFilter]
        [MyResultFilter]
        public ActionResult AB()
        {
            Response.Write("<div class=\"container\"><h2>Action AB</h2></div>");
            return View("Index");
        }

        [MyActionFilter]
        public ActionResult AC()
        {
            Response.Write("<div class=\"container\"><h2>Action AC</h2></div>");
            return View("Index");
        }
    }
}