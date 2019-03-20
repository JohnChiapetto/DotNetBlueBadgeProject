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
        public bool CreateRole(RoleCreate model)
        {
            IdentityRole role = new IdentityRole()
            {
                Name = model.RoleName
            };
            roleManager.Create(role);
            return context.TrySave();
        }
        public bool DeleteRole(RoleDelete model) {
            roleManager.Delete(GetRoles(e=>e.Id == model.RoleID.ToString())[0]);
            return context.TrySave();
        }
    }
}
