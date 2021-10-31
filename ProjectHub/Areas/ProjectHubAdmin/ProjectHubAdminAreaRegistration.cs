using System.Web.Mvc;

namespace ProjectHub.Areas.ProjectHubAdmin
{
    public class ProjectHubAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProjectHubAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProjectHubAdmin_default",
                "ProjectHubAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}