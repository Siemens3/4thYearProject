using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestForIdenty.Startup))]
namespace TestForIdenty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
