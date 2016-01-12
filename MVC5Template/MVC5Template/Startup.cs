using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5Template.Startup))]
namespace MVC5Template
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
