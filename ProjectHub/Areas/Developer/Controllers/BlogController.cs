using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.Developer.Controllers
{
    public class BlogController : Controller
    {
        // GET: Developer/Blog
        public ActionResult AddBlog()
        {
            return View();
        }
        public ActionResult MyBlogList()
        {
            return View();
        }
    }
}