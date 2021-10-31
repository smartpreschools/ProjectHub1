using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: ProjectHubAdmin/Projects
        public ActionResult ProjectCategory()
        {
            return View();
        }
        public ActionResult ProjectSubCategory()
        {
            return View();
        }
        public ActionResult AddProject()
        {
            return View();
        }

        public ActionResult ProjectList()
        {
            return View();
        }
        public ActionResult ProjectDetails()
        {
            return View();
        }
    }
}