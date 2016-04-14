using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Paylocity.Web.Startup))]
namespace Paylocity.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
