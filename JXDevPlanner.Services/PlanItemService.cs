using JXDevPlanner.Data;
using JXDevPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    public class PlanItemService : AbstractService
    {
        public PlanItemService(Guid userId) : base(userId) { }

        public PlanItem GetPlanItemById(Guid id) {
            return Context.PlanItems.Where(e => e.PlanItemID == id).Single();
        }
        public PlanItem[] GetPlans(Guid projectID) {
            return Context.PlanItems.Where(e => e.ProjectID == projectID && e.CreatorID == _userId).ToArray();
        }
        public PlanListItem[] GetPlanListItems(Guid projectID) {
            PlanItem[] items = GetPlans(projectID);
            PlanListItem[] listItems = new PlanListItem[items.Length];
            int i = 0;
            foreach (var item in items)
            {
                listItems[i] = new PlanListItem(item);
                listItems[i++].CreatorName = Context.Users.Where(e => e.Id == _userId.ToString()).Single().UserName;
            }
            return listItems;
        }

        public bool CreatePlanItem(PlanItemCreate model)
        {
            PlanItem entity = new PlanItem
            {
                PlanItemID = Guid.NewGuid(),
                Name = model.Name,
                Details = model.Detail,
                ProjectID = model.ProjectID,
                CreatorID = _userId,
                LastModifiedBy = _userId,
                CreatedUTC = DateTimeOffset.Now,
                ModifiedUTC = null
            };
            Context.PlanItems.Add(entity);
            return Context.TrySave();
        }

        public bool EditPlanItem(PlanItemEdit model)
        {
            PlanItem entity    = GetPlanItemById(model.PlanID);
            entity.Name        = model.Name;
            entity.Details     = model.Detail;
            entity.ModifiedUTC = DateTimeOffset.Now;
            entity.LastModifiedBy = _userId;
            return Context.TrySave();
        }

        public Guid DeletePlanItem(Guid id) {
            PlanItem val = GetPlanItemById(id);
            var pid = GetProjectIdFor(id);
            //Context.PlanItems.Attach(val);
            //if (Context.PlanItems.AsNoTracking().Contains(val))
            //{
                Context.PlanItems.Remove(val);
            //}
            Context.TrySave();
            return pid;
        }

        public Project GetProjectFor(Guid id) {
            var q = new ProjectService(_userId).GetProject(GetProjectIdFor(id));
            return q;
        }
        public Guid GetProjectIdFor(Guid id) {
            return GetPlanItemById(id).ProjectID;
        }
    }
}
