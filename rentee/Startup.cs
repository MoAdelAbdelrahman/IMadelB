using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rentee.Startup))]
namespace rentee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
