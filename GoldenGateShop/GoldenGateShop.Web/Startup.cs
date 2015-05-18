using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoldenGateShop.Web.Startup))]
namespace GoldenGateShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
