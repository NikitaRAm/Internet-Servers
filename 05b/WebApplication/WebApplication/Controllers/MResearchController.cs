﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        [HttpGet]
        [Route("{n:int}/{str}")]
        public ActionResult M01(int? n, string str)
        {
            Response.Write("<div class=\"container\"><h3>" + n.Value + " - " + str + "</h3></div>");
            return View();
        }

        [AcceptVerbs("GET", "POST")]
        [Route("{b:bool}/{letters:alpha}")]
        public ActionResult M02(bool? b, string letters)
        {
            Response.Write("<div class=\"container\"><h3>" + b.Value + " - " + letters + "</h3></div>");
            return View();
        }

        [AcceptVerbs("GET", "DELETE")]
        [Route("{f:float}/{str:length(1,6)}")]
        public ActionResult M03(float? f, string str)
        {

            Response.Write("<div class=\"container\"><h3>" + f.Value + " - " + str + "</h3></div>");
            return View("M03");

        }

        [HttpPut]
        [Route("{letters:length(2,5)}/{n:range(100, 200)}")]
        public ActionResult M04(string letters, int? n)
        {
            Response.Write("<div class=\"container\"><h3>" + letters + " - " + n.Value + "</h3></div>");
            return View();
        }

        [HttpPost]
        [Route(@"{mail:regex(^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$)}")]
        public ActionResult M04(string mail)
        {
            Response.Write("<div class=\"container\"><h3>" + mail + "</h3></div>");
            return View();
        }

        [HttpGet]
        public ActionResult MXX()
        {
            return View("Error");
        }
    }
}