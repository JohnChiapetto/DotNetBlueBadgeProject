using JXDevPlanner.Data;
using JXDevPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXDevPlanner.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }

        public Project GetProject(Guid id) {
            using (var ctx = new ApplicationDbContext()) {
                return ctx.Projects.Where(e => e.ProjectID == id).Single();
            }
        }

        public bool EditProject(ProjectEdit model) {
            using (var ctx = new ApplicationDbContext()) {
                var entity = ctx.Projects.Where(e => e.ProjectID == model.ProjectID).Single();
                entity.Title = model.Title;
                entity.Desc = model.Desc;
                entity.ModifiedUTC = DateTimeOffset.Now;
                //ctx.Projects.Remove(ctx.Projects.Where(e => e.ProjectID == model.ProjectID).Single());
                //ctx.Projects.Add(entity);
                return ctx.TrySave();
            }
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity = new Project()
            {
                Creator     = _userId,
                Title       = model.Title,
                Desc = model.Desc,
                CreatedUTC  = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.TrySave();
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Projects
                        .Where(e => e.Creator == _userId)
                        .Select(
                            e => new ProjectListItem { ProjectID = e.ProjectID,Desc = e.Desc, Title = e.Title,CreatedUtc = e.CreatedUTC }
                        );
                return query.ToArray();
            }
        }

        public ProjectDetail GetProjectById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => true/*e.ProjectID == id && e.Creator == _userId*/);
                ProjectDetail pd = new ProjectDetail(entity);
                pd.CreatorName = ctx.Users.Where(e => e.Id == pd.Creator.ToString()).Single().UserName;
                PlanItem[] items = ctx.PlanItems.Where(e => true).ToArray();
                pd.PlanItems = new PlanListItem[items.Length];
                for (int i = 0; i < pd.PlanItems.Length; i++) {
                    pd.PlanItems[i] = new PlanListItem(items[i]);
                }
                return pd;
            }
        }

        public bool DeleteProject(Guid id) {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Remove(ctx.Projects.Where(e => e.ProjectID == id).Single());
                return ctx.TrySave();
            }
        }
        public ProjectDelete CreateProjectDeleteModel(Guid id) {
            using (var ctx = new ApplicationDbContext())
            {
                ProjectDelete model = new ProjectDelete(ctx.Projects.Where(e => e.ProjectID == id).Single());
                model.OwnerName = ctx.Users.Where(e => e.Id == model.Owner.ToString()).Single().UserName;
                return model;
            }
        }
    }
}
