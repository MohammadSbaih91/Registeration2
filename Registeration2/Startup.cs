using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Registeration2.StartupOwin))]

namespace Registeration2
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
