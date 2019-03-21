﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Data
{
    public class UserRole
    {
        public Guid UserRoleID { get; set; }
        public Guid RoleID { get; set; }
        public Guid UserID { get; set; }

        public UserRole(IdentityUser user,IdentityRole role)
        {
            this.UserRoleID = Guid.NewGuid();
            this.UserID = Guid.Parse(user.Id);
            this.RoleID = Guid.Parse(role.Id);
        }
        public UserRole(ApplicationUser user,IdentityRole role)
        {
            this.UserRoleID = Guid.NewGuid();
            this.UserID = Guid.Parse(user.Id);
            this.RoleID = Guid.Parse(role.Id);
        }
    }
}
