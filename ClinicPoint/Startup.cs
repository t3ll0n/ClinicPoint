using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClinicPoint.Startup))]
namespace ClinicPoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
