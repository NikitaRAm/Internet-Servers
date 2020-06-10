using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ConversationController : Controller
    {
        public JsonResult WithContact(int contact)
        {
			if (Session["user"] == null)
			{
				return Json(new { status = "error", message = "User is not logged in" });
			}
			
			var currentUser = (Models.User)Session["user"];

            var conversations = new List<Models.Conversation>();

            using ( var db = new Models.UserContext() ) {
                conversations = db.Conversations.
                                  Where(c => (c.receiver_id == currentUser.Id && c.sender_id == contact) || (c.receiver_id == contact && c.sender_id == currentUser.Id))
                                  .OrderBy( c => c.created_at )
                                  .ToList();
            }

            return Json( new{ status = "success", data = conversations });
        }
    }
}
