using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(MVC5Template.Startup))]

namespace MVC5Template
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
