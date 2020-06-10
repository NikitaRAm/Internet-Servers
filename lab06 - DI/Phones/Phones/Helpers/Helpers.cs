using PhonesLibSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phones.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString HelperButton(this HtmlHelper html, string mission)
        {
            return new MvcHtmlString($"<input type='submit' value='{mission}' class='btn btn-default' />");
        }

        public static MvcHtmlString HelperSurname(this HtmlHelper html, Contact contact)
        {
            if (contact == null)
            {
                return new MvcHtmlString($"<input class='form-control text-box single-line' id='Surname' name='Surname' type='text' value=''>");
            }
            else
            {
                return new MvcHtmlString($"<input class='form-control text-box single-line' id='Surname' name='Surname' type='text' value='{contact.Surname}'>");
            }
        }

        public static MvcHtmlString HelperPhone(this HtmlHelper html, Contact contact)
        {
            if (contact == null)
            {
                return new MvcHtmlString($"<input class='form-control text-box single-line' id='Phone' name='Phone' type='text' value=''>");
            }
            else
            {
                return new MvcHtmlString($"<input class='form-control text-box single-line' id='Phone' name='Phone' type='text' value='{contact.Phone}'>");
            }
        }
    }
}