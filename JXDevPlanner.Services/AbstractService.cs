using JXDevPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    public abstract class AbstractService
    {
        public static ApplicationDbContext Context;

        protected Guid _userId;

        public AbstractService() : this(new Guid()) { }
        public AbstractService(Guid userId) {
            if (Context == null)
                Context = new ApplicationDbContext();
            this._userId = userId;
        }


        public void CheckAndRemoveUnbound()
        {
            List<PlanItem> itemsToRemove = new List<PlanItem>();
            List<PlanItemPromotion> promotionsToRemove = new List<PlanItemPromotion>();
            List<UserRole> userRolesToRemove = new List<UserRole>();
            foreach (var item in Context.PlanItems)
            {
                if (Context.Projects.Where(e => e.ProjectID == item.ProjectID).Count() < 1) itemsToRemove.Add(item);
            }
            foreach (var item in Context.Promotions)
            {
                if (Context.PlanItems.Where(e => e.PlanItemID == item.PlanId).Count() < 1) promotionsToRemove.Add(item);
            }
            foreach (var item in Context.UserRoles)
            {
                if (Context.Users.Where(e => e.Id == item.UserID.ToString()).Count() < 1) userRolesToRemove.Add(item);
            }
            Context.Promotions.RemoveRange(promotionsToRemove);
            Context.PlanItems.RemoveRange(itemsToRemove);
            Context.UserRoles.RemoveRange(userRolesToRemove);
            Context.SaveChanges();
        }
    }
}
