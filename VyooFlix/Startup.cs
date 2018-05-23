using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VyooFlix.Startup))]
namespace VyooFlix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
