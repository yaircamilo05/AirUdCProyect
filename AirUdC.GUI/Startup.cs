using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirUdC.GUI.Startup))]
namespace AirUdC.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
