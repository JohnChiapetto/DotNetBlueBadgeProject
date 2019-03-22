using JXDevPlanner.Data;
using JXDevPlanner.Models;
using JXDevPlanner.Storage;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using JXDevPlanner.WebMVC;

namespace JXDevPlanner.Services
{
    public class AccountService : AbstractService
    {
        dynamic UserManager;

        public AccountService(Guid uid,dynamic userManager) : base(uid)
        {
            this.UserManager = userManager;
        }

        public static bool IsAdmin(Guid userID) {
            using (var ctx = new ApplicationDbContext()) {
                var q = ctx.Users.Where(e => e.Id == userID.ToString()).ToArray();
                if (q.Length < 1) return false;
                foreach (var role in ctx.Users.Where(e => e.Id == userID.ToString()).Single().Roles) {
                    if (role.ToString() == "Admin") return true;
                }
            }
            return false;
        }

        public static AccountListItem[] GetAccountListItems() {
            using (var ctx = new ApplicationDbContext())
            {
                List<AccountListItem> items = new List<AccountListItem>();
                foreach (var user in ctx.Users) items.Add(new AccountListItem(user));
                return items.ToArray();
            }
        }

        public IdentityUser GetUserById(string id) => GetUserById(Guid.Parse(id));
        public IdentityUser GetUserById(Guid id) => Context.Users.Where(e => e.Id == id.ToString()).Single();

        public async void CreateAccountAsync(string userName,string email,string password)
        {
            Context.SaveChanges();
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email
            };
            //if (GStorage.Data["UserManager"] == null) throw new Exception("USERMANAGER GLOBAL IS NULL");
            var result = await UserManager.Create(user,password);
            Context.SaveChanges();
            //success = Context.SaveChanges() != 0;
        }
        public void CreateAccount(string userName,string email,string password)
        {
            CreateAccountAsync(userName,email,password);
        }

        public IdentityRole[] GetRolesForUser(Guid id) => GetRolesForUser(GetUserById(id));
        public IdentityRole[] GetRolesForUser(IdentityUser user) => new UserRoleService(_userId,UserManager).GetRoles(Guid.Parse(user.Id));

    }
}
