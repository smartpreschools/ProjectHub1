using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: ProjectHubAdmin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}