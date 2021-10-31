using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.Developer.Controllers
{
    public class TestPaperController : Controller
    {
        // GET: Developer/TestPaper
        public ActionResult TestPaper()
        {
            return View();
        }
        public ActionResult TestContent()
        {
            return View();
        }
        public ActionResult MyTestList()
        {
            return View();
        }
    }
}