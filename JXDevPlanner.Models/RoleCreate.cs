﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Models
{
    public class RoleCreate
    {
        [Display(Name="Name")]
        public string RoleName { get; set; }
        public Guid RoleID { get; set; }
    }
}
