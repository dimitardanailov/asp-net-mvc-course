using System.Web.Mvc;

namespace BeehiveStore.Areas.StoreAdministrator
{
    public class StoreAdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StoreAdministrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute
            (
                name: "CategoryModerationDetails",
                url: "StoreAdministrator/category/show/{id}",
                defaults: new
                {
                    controller = "CategoryModeration",
                    action = "Details"
                }
            );

            context.MapRoute(
                "StoreAdministrator_default",
                "StoreAdministrator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}