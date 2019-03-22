using JXDevPlanner.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    public class UserRoleService : AbstractService
    {
        public UserRoleService(Guid uid,dynamic um) : base(uid) { UserManager = um; }
        public dynamic UserManager;

        public UserRole GetById(Guid id)
        {
            try
            {
                return Context.UserRoles.Where(e => e.UserRoleID == id).Single();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public IdentityRole[] GetRoles(Guid userID)
        {
            var roleService = new RoleService(userID);
            var roles = new List<IdentityRole>();
            foreach (var ur in Context.UserRoles.Where(e => e.UserID == userID).ToList())
            {
                roles.Add(roleService.GetRoleById(ur.RoleID));
            }
            return roles.ToArray();
        }
        public void AssignRole(Guid user,IdentityRole role)
        {
            Context.UserRoles.Add(new UserRole(new AccountService(_userId,UserManager).GetUserById(user),role));
            Context.TrySave();
        }
    }
}
