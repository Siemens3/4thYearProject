using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureCal.Startup))]
namespace AzureCal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
