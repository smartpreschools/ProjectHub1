using ProjectHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin.Controllers
{
    public class MasterController : Controller
    {
        private readonly MasterBLL masterBLLobj = new MasterBLL();
       
        [HttpGet]
        public ActionResult GetDropDownData(string dropName, string inputText)
        {
            
            return Json(masterBLLobj.GetDropDownData(dropName, inputText), JsonRequestBehavior.AllowGet);
        }
    }
}