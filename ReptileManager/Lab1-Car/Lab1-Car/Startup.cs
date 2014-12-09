using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab1_Car.Startup))]
namespace Lab1_Car
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
