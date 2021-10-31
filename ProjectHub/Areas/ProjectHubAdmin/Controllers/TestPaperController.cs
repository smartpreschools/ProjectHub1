using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin.Controllers
{
    public class TestPaperController : Controller
    {
        // GET: ProjectHubAdmin/TestPaper
        public ActionResult Technology()
        {
            return View();
        }
        public ActionResult AddTestPaper()
        {
            return View();
        }
        public ActionResult TestContent()
        {
            return View();
        }
        public ActionResult TestList()
        {
            return View();
        }
        public ActionResult PendingTestList()
        {
            return View();
        }
    }
}