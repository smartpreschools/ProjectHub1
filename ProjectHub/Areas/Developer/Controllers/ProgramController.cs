using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.Developer.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Developer/Program
        public ActionResult AddProgram()
        {
            return View();
        }
        public ActionResult MyProgramList()
        {
            return View();
        }
        
    }
}