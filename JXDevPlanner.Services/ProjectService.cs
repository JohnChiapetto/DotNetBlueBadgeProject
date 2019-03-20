using JXDevPlanner.Data;
using JXDevPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    public class ProjectService : AbstractService
    {
        public ProjectService(Guid userId) : base(userId) { }

        public Project GetProject(Guid id)
        {
            return Context.Projects.Where(e => e.ProjectID == id).Single();
        }

        public bool EditProject(ProjectEdit model)
        {
            var entity = Context.Projects.Where(e => e.ProjectID == model.ProjectID).Single();
            entity.Title = model.Title;
            entity.Desc = model.Desc;
            entity.ModifiedUTC = DateTimeOffset.Now;
            //ctx.Projects.Remove(ctx.Projects.Where(e => e.ProjectID == model.ProjectID).Single());
            //ctx.Projects.Add(entity);
            return Context.TrySave();
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity = new Project()
            {
                Creator = _userId,
                Title = model.Title,
                Desc = model.Desc,
                CreatedUTC = DateTimeOffset.Now
            };
            Context.Projects.Add(entity);
            return Context.TrySave();
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            var query =
                Context
                    .Projects
                    .Where(e => e.Creator == _userId)
                    .Select(
                        e => new ProjectListItem { ProjectID = e.ProjectID,Desc = e.Desc,Title = e.Title,CreatedUtc = e.CreatedUTC }
                    );
            return query.ToArray();
        }

        public ProjectDetail GetProjectById(Guid id)
        {
            var entity =
                Context
                    .Projects
                    .Single(e => true/*e.ProjectID == id && e.Creator == _userId*/);
            ProjectDetail pd = new ProjectDetail(entity);
            pd.CreatorName = Context.Users.Where(e => e.Id == pd.Creator.ToString()).Single().UserName;
            PlanItem[] items = Context.PlanItems.Where(e => true).ToArray();
            pd.PlanItems = new PlanListItem[items.Length];
            for (int i = 0; i < pd.PlanItems.Length; i++)
            {
                pd.PlanItems[i] = new PlanListItem(items[i]);
            }
            return pd;
        }

        public bool DeleteProject(Guid id)
        {
            Context.Projects.Remove(Context.Projects.Where(e => e.ProjectID == id).Single());
            return Context.TrySave();
        }
        public ProjectDelete CreateProjectDeleteModel(Guid id)
        {
            ProjectDelete model = new ProjectDelete(Context.Projects.Where(e => e.ProjectID == id).Single());
            model.OwnerName = Context.Users.Where(e => e.Id == model.Owner.ToString()).Single().UserName;
            return model;
        }
    }
}
