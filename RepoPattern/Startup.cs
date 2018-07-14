using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RepoPattern.Startup))]
namespace RepoPattern
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
