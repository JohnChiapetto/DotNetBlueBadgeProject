using JXDevPlanner.Data;
using JXDevPlanner.Models;
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
        ApplicationUserManager UserManager;

        public AccountService(Guid uid) : base(uid) { }

        public static bool IsAdmin(Guid userID) {
            using (var ctx = new ApplicationDbContext()) {
                var q = ctx.Users.Where(e => e.Id == userID.ToString()).ToArray();
                if (q.Length < 1) return false;
                foreach (var role in ctx.Users.Where(e => e.Id == userID.ToString()).Single().Roles) {
                    throw new Exception(role.ToString());
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

        public IdentityUser GetUserById(Guid id) => Context.Users.Where(e => e.Id == id.ToString()).Single();

    }
}
