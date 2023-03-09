using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2080600068_TranDuyAnh_BigSchool.Startup))]
namespace _2080600068_TranDuyAnh_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
