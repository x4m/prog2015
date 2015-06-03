using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Contacts;

namespace WebContacts.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        ClassContacts cs=new ClassContacts();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View("AutificatedNULL");
            InitContacts();
            // if (System.IO.File.Exists(GetSportsmensName())) return View("NotFile");
            return View(cs);
        }

        private void InitContacts()
        {
            var spName = GetContacts();
            if (spName != null && System.IO.File.Exists(spName))
            {
                var file = System.IO.File.OpenRead(spName);
                var xs = new XmlSerializer(typeof(ClassContacts));
                cs = (ClassContacts)xs.Deserialize(file);
                file.Close();
            }
            else
            {
                cs = new ClassContacts();
            }
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            file.SaveAs(GetContacts());
            InitContacts();
            Index();
            return View("Index");
        }
        private string GetContacts()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated == false) return null;
            return Server.MapPath("~\\App_Data\\" + name + ".contacts");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}