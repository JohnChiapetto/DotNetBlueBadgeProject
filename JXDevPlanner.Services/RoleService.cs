using JXDevPlanner.Data;
using JXDevPlanner.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    

    public class RoleService : AbstractService
    {
        //Guid _userId;
        ApplicationDbContext context = new ApplicationDbContext();
        RoleManager<IdentityRole> roleManager;

        public RoleService(Guid userId) : base(userId) { this.roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)); }

        public IdentityRole[] GetRoles() { return GetRoles(e => true); }
        public IdentityRole[] GetRoles(Expression<Func<IdentityRole,bool>> query)
        {
            return context.Roles.Where(query).ToArray();
        }
        public IdentityRole GetRoleByName(string name) => Context.Roles.Where(e => e.Name == name).ToArray()[0];

        public bool EditRole(RoleEdit model)
        {
            GetRoleById(model.RoleID).Name = model.Name;
            return Context.TrySave();
        }

        public bool CreateRole(RoleCreate model)
        {
            var identr = new IdentityRole(model.RoleName);
            IdentityResult result = roleManager.Create(identr);
            // Just in case...
            model.RoleID = Guid.Parse(identr.Id);
            context.SaveChanges();
            return result.Succeeded;
        }
        public void DeleteRole(RoleDelete model) {
            var role = GetRoleById(model.RoleID);
            new UserRoleService(new Guid(),JXDevPlanner.Storage.GStorage.Data["UserManager"]).RemoveAllFromRole(Guid.Parse(role.Id));
            Context.Roles.Remove(role);
            context.TrySave();
        }
        public IdentityRole GetRoleById(Guid id)
        {
            var qar = Context.Roles.Where(e => e.Id == id.ToString()).ToArray();
            if (qar.Length < 1) return null;
            return qar[0];
        }
        public void CreateRole(string name)
        {
            var role =new IdentityRole(name);
            role.Id = Guid.NewGuid().ToString();
            //roleManager.Create(new IdentityRole { Name = name });
            Context.Roles.Add(role);
            Context.SaveChanges();
        }
        public bool Exists(string name) => Context.Roles.Where(e => e.Name == name).ToArray().Length > 0;
    }
}
