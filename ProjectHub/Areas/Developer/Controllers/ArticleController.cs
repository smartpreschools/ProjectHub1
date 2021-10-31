using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.Developer.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Developer/Article
        public ActionResult AddArticle()
        {
            return View();
        }
        public ActionResult MyArticleList()
        {
            return View();
        }
    }
}