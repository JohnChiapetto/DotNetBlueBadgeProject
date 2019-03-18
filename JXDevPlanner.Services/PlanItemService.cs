using JXDevPlanner.Data;
using JXDevPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    public class PlanItemService
    {
        private readonly Guid _userId;

        public PlanItemService(Guid userId)
        {
            _userId = userId;
        }

        public PlanItem[] GetPlans(Guid projectID) {
            return new ApplicationDbContext().PlanItems.Where(e => e.ProjectID == projectID && e.CreatorID == _userId).ToArray();
        }
        public PlanListItem[] GetPlanListItems(Guid projectID) {
            using (var ctx = new ApplicationDbContext()) {
                PlanItem[] items = GetPlans(projectID);
                PlanListItem[] listItems = new PlanListItem[items.Length];
                int i = 0;
                foreach (var item in items) listItems[i++] = new PlanListItem(item);
                return listItems;
            }
        }

        public bool CreatePlanItem(PlanItemCreate model)
        {
            using (var ctx = new ApplicationDbContext()) {
                PlanItem entity = new PlanItem {
                    PlanItemID = Guid.NewGuid(),
                    Name = model.Name,
                    Details = model.Detail,
                    ProjectID = model.ProjectID,
                    CreatorID = _userId,
                    LastModifiedBy = _userId,
                    CreatedUTC = DateTimeOffset.Now,
                    ModifiedUTC = null
                };
                ctx.PlanItems.Add(entity);
                return ctx.TrySave();
            }
        }
    }
}
