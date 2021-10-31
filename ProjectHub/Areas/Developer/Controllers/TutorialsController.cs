using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.Developer.Controllers
{
    public class TutorialsController : Controller
    {
        // GET: Developer/Tutorials
        public ActionResult AddTutorials()
        {
            return View();
        }
        public ActionResult MyTutorialList()
        {
            return View();
        }
    }
}