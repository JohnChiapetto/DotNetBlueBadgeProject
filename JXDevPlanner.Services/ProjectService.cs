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
                return ctx.SaveChanges() == 1;
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
                        .Single(e => e.ProjectID == id && e.Creator == _userId);
                return new ProjectDetail(entity);
            }
        }
    }
}
