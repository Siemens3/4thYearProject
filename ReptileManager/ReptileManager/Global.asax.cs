using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Logging;
using Persistence;


namespace ReptileManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            PhotoService photoService = new PhotoService(new Logger());
            photoService.CreateAndConfigureAsync();

        }

       
        
    }
}
