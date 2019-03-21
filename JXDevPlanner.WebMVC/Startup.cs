using JXDevPlanner.Services;
using Microsoft.Owin;
using Owin;
using System;
using System.Web;

[assembly: OwinStartupAttribute(typeof(JXDevPlanner.WebMVC.Startup))]
namespace JXDevPlanner.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var roleService = new RoleService(new Guid());
            var AccountService = new AccountService();
            if (!roleService.Exists("Admin"))
            {
                roleService.CreateRole("Admin");

            }
        }
    }
}
