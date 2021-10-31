using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin.Controllers
{
    public class InterviewController : Controller
    {
        // GET: ProjectHubAdmin/Interview
        public ActionResult Technology()
        {
            return View();
        }

        public ActionResult Question()
        {
            return View();
        }

        public ActionResult QuestionList()
        {
            return View();
        }

        public ActionResult PendingList()
        {
            return View();
        }
    }
}