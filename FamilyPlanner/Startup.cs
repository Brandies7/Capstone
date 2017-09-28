using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamilyPlanner.Startup))]
namespace FamilyPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
