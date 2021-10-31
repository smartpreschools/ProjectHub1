using ProjectHub.Common.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
      
        public ActionResult Login(LoginModel model)
        {
            if (model.UserName.Trim().ToUpper() == "admin".ToUpper() && model.UserName.Trim().ToUpper() == "admin".ToUpper())
            {
                Session["UserID"]= "C0FE9326-771B-41B8-963C-7D4688AF7865";
                return RedirectToAction("../ProjectHubAdmin/Dashboard/");
            }
            if (model.UserName.Trim().ToUpper() == "developer".ToUpper() && model.UserName.Trim().ToUpper() == "Developer".ToUpper())
            {
                return RedirectToAction("../Developer/Dashboard/");
            }
            return View();
        }
    }
}