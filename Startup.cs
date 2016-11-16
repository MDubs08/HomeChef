using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeChef.Startup))]
namespace HomeChef
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
