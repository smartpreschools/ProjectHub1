using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.Developer.Controllers
{
    public class InterviewController : Controller
    {
        // GET: Developer/Interview
        public ActionResult AddQuestion()
        {
            return View();
        }
        public ActionResult MyQuestionlist()
        {
            return View();
        }
    }
}