using JXDevPlanner.Data;
using JXDevPlanner.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                Category = model.Category,
                CreatorID = _userId,
                LastModifiedBy = _userId,
                CreatedUTC = DateTimeOffset.Now,
                ModifiedUTC = null
            };
            UpdateProjectModifiedDate(model.ProjectID);
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
            UpdateProjectModifiedDate(model.ProjectID);
            Context.TrySave();
            return true;
        }

        public Guid DeletePlanItem(Guid id) {
            PlanItem val = GetPlanItemById(id);
            var project = new ProjectService(_userId).GetProjectById(val.ProjectID);
            project.ModifiedUTC = DateTimeOffset.Now;
            var pid = project.ProjectID;
            //Context.PlanItems.Attach(val);
            //if (Context.PlanItems.AsNoTracking().Contains(val))
            //{
                Context.PlanItems.Remove(val);
            //}
            Context.Promotions.RemoveRange(Context.Promotions.Where(e => e.PlanId == id));
            Context.TrySave();
            CheckAndRemoveUnbound();
            return pid;
        }

        public bool UpdateProjectModifiedDate(Guid projectId)
        {
            new ProjectService(_userId).GetProjectById(projectId).ModifiedUTC = DateTimeOffset.Now;
            return Context.TrySave();
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
