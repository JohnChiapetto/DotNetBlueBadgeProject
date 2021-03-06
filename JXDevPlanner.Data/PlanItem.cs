﻿using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Data
{
    public enum PlanCategory : int
    {
        Stable,Working,Indev,Promised,Planned,Proposed
    }

    public class PlanItem
    {

        [Key]
        public Guid PlanItemID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public Guid ProjectID { get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        public Guid CreatorID { get; set; }

        [Required]
        public Guid LastModifiedBy { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; } = null;

        //[Ignored]
        public string CategoryString => CategoryStr(this.Category);

        public static string CategoryStr(int n) => Enum.GetName(typeof(PlanCategory),n);

    }
}
