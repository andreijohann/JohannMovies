using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JohannMovies.Startup))]
namespace JohannMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
