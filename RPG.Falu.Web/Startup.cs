using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RPG.Falu.Web.Startup))]
namespace RPG.Falu.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
