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
        public IdentityRole[] GetRolesUserIsNotIn(Guid userID)
        {
            var roleService = new RoleService(userID);
            var roles = new List<IdentityRole>();
            var xroles = Context.Roles.Where(e => true).ToList();
            foreach (var ur in Context.UserRoles.Where(e => e.UserID == userID).ToList())
            {
                xroles.Remove(xroles.Where(e => e.Id == ur.RoleID.ToString()).Single());
            }
            return xroles.ToArray();
        }
        //public ApplicationUser[] GetUsers(Guid roleID)
        //{
        //    var usvc = new AccountService(_userId,GSt)
        //    var users = new List<ApplicationUser>();
        //    foreach (var ur in Context.UserRoles.Where(e => e.RoleID == roleID).ToList())
        //    {
        //        users.Add()
        //    }
        //}
        public void RemoveUnmapped()
        {
            var rsvc = new RoleService(new Guid());
            var rcache = new List<Guid>();
            foreach (var ur in Context.UserRoles.Where(e => true))
            {
                if (rsvc.GetRoleById(ur.RoleID) == null) Context.UserRoles.Remove(ur);
            }
            Context.SaveChanges();
        }
        public void RemoveAllFromRole(Guid roleID)
        {
            foreach (var ur in Context.UserRoles.Where(e => e.RoleID == roleID).ToList())
            {
                Context.UserRoles.Remove(ur);
            }
            Context.SaveChanges();
        }
        public void AssignRole(Guid user,IdentityRole role)
        {
            Context.UserRoles.Add(new UserRole(new AccountService(_userId,UserManager).GetUserById(user),role));
            
            Context.TrySave();
        }
        public void UnassignRole(Guid user,Guid role)
        {
            Context.UserRoles.Remove(Context.UserRoles.Where(e=>e.RoleID == role && e.UserID == user).Single());

            Context.TrySave();
        }

        public bool IsUserInRole(Guid userID,string name)
        {
            var rsvc = new RoleService(_userId);
            var role = rsvc.GetRoleByName(name);
            var userRoles = Context.UserRoles.Where(e => e.UserID == userID).Where(e => e.RoleID.ToString() == role.Id).ToArray();
            return userRoles.Length > 0;
        }
    }
}
