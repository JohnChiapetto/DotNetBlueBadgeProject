using JXDevPlanner.Data;
using JXDevPlanner.Services;
using JXDevPlanner.Storage;
using JXDevPlanner.WebMVC.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.WebPages;
using System.Security.Principal;
//using System.Web.WebPages;

[assembly: OwinStartupAttribute(typeof(JXDevPlanner.WebMVC.Startup))]
namespace JXDevPlanner.WebMVC
{
    public static class UserExt
    {
        public static bool IsUserInRole_J(IPrincipal user,string RoleName)
        {
            if (user == null) return false;
            var userStore = new UserStore<ApplicationUser>(AbstractService.Context);
            var userManager = new ApplicationUserManager(userStore);
            var uid = user.Identity.GetUserId();
            if (uid == null) return false;
            return new UserRoleService(new Guid(),userManager).IsUserInRole(Guid.Parse(uid),"Admin");
        }
    }

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
            var userRoleService = new UserRoleService(new Guid(),v);
            if (!roleService.Exists("Admin"))
            {
                roleService.CreateRole("Admin");
                var user = new ApplicationUser
                {
                    UserName = "ADMINISTRATOR_GOD",
                    Email = "admin@admin.com"
                };
                //if (GStorage.Data["UserManager"] == null) throw new Exception("USERMANAGER GLOBAL IS NULL");
                var result = v.Create(user,"SATAN@666");
                var urs = new UserRoleService(new Guid(),v);
                urs.AssignRole(Guid.Parse(user.Id),roleService.GetRoleByName("Admin"));
                AbstractService.Context.SaveChanges();
            }
            //userRoleService.RemoveUnmapped();
        }
    }
}
