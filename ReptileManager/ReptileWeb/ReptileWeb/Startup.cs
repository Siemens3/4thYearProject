using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReptileWeb.Startup))]
namespace ReptileWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
