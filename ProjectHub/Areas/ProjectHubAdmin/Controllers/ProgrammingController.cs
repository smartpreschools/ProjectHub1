using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin.Controllers
{
    public class ProgrammingController : Controller
    {
        // GET: ProjectHubAdmin/Programming
        public ActionResult Technology()
        {
            return View();
        }
        public ActionResult Topic()
        {
            return View();
        }

        public ActionResult Program()
        {
            return View();
        }
        public ActionResult ProgramList()
        {
            return View();
        }
        public ActionResult PendingList()
        {
            return View();
        }
    }
}