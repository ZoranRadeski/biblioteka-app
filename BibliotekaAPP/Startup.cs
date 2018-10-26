using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BibliotekaAPP.Startup))]
namespace BibliotekaAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
