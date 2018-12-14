using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBLoginLePAPEO.Startup))]
namespace WEBLoginLePAPEO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
