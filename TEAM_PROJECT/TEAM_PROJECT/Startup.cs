using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TEAM_PROJECT.Startup))]
namespace TEAM_PROJECT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
