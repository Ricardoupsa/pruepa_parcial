using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADMparcial1.Startup))]
namespace ADMparcial1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
