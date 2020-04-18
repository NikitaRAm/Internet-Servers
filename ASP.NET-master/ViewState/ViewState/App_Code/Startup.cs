using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ViewState.Startup))]
namespace ViewState
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
