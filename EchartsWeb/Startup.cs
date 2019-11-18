using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EchartsWeb.Startup))]
namespace EchartsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
