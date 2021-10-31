using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin.Controllers
{
    public class BlogsController : Controller
    {
        // GET: ProjectHubAdmin/Blogs
        public ActionResult BlogCategory()
        {
            return View();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public ActionResult BlogList()
        {
            return View();
        }
        public ActionResult PendingBlogList()
        {
            return View();
        }
    }
}