using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab7_WebAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class PageController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index()
        {
            return Content(
                System.IO.File.ReadAllText(@"E:\Education\Programming_Internet-Servers\Labs\Internet-Servers\Lab7_WebAPI\Lab7_WebAPI\Views\main_page.html"),
                "text/html"
            );
        }
    }
}