using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReptileManager.Startup))]
namespace ReptileManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
