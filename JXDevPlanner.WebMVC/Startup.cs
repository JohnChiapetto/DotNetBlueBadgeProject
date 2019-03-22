using JXDevPlanner.Data;
using JXDevPlanner.Services;
using JXDevPlanner.Storage;
using JXDevPlanner.WebMVC.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Net;
using System.Web;

[assembly: OwinStartupAttribute(typeof(JXDevPlanner.WebMVC.Startup))]
namespace JXDevPlanner.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            if (AbstractService.Context == null) AbstractService.Context = new ApplicationDbContext();
            var store = new UserStore<ApplicationUser>(AbstractService.Context);
            var v = new ApplicationUserManager(store);
            //var v = new ApplicationUserManager((IUserStore<ApplicationUser>)AbstractService.Context.Users);
            var roleService = new RoleService(new Guid());
            //var accntCnt = new AccountController(v,new ApplicationSignInManager(v,null));
            var accountService = new AccountService(Guid.NewGuid(),v);
            if (!roleService.Exists("Admin"))
            {
                roleService.CreateRole("Admin");
                accountService.CreateAccount("ADMINISTRATOR GOD","admin@admin.com","SATAN@666");
                AbstractService.Context.SaveChanges();
            }
        }
    }
}
