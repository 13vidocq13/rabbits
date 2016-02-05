using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rabbits.Startup))]
namespace Rabbits
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
