using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionGarage.Startup))]
namespace GestionGarage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
