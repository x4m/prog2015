using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using WindowsFormsApplication1;


namespace WebRegistrations.Controllers
{
    public class HomeController : Controller
    {
        private Participant par;
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View("AutificatedNULL");
            InitParticip();
            return View(par);  
        }
        private void InitParticip()
        {
            var parName = GetPARTName();
            if (parName != null && System.IO.File.Exists(parName))
            {
                var file = System.IO.File.OpenRead(parName);
                var xs = new XmlSerializer(typeof(Participant));
                par = (Participant) xs.Deserialize(file);
                file.Close();
            }
            else
            {
                par = new Participant();
            }
        }
        public ActionResult Upload(HttpPostedFileBase file)
        {
            file.SaveAs(GetPARTName());
            InitParticip();
            Index();
            return View("Index");
        }
        private string GetPARTName()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated == false) return null;
            return Server.MapPath("~\\App_Data\\" + name + ".participant");
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