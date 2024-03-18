using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CNPMNC1.App_Start.StartUp))]
namespace CNPMNC1.App_Start
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}