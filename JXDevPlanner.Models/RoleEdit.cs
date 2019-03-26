using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace JXDevPlanner.Models
{
    public class RoleEdit
    {
        public Guid RoleID { get; set; }
        public string Name { get; set; }
        public string ReturnUrl { get; set; }

        public RoleEdit() { }
        public RoleEdit(IdentityRole role,string returnUrl) : this()
        {
            this.RoleID = Guid.Parse(role.Id);
            this.Name = role.Name;
            this.ReturnUrl = returnUrl;
        }
    }
}