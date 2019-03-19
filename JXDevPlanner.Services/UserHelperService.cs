using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    public class UserHelperService
    {
        public static bool IsAdmin(Guid userID) {
            using (var ctx = new ApplicationDbContext()) {
                foreach (var role in ctx.Users.Where(e => e.Id == userID.ToString()).Single().Roles) {
                    throw new Exception(role.ToString());
                    if (role.ToString() == "Admin") return true;
                }
            }
            return false;
        }
    }
}
