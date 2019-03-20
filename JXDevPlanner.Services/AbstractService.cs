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
        protected static ApplicationDbContext Context = new ApplicationDbContext();

        protected Guid _userId;

        public AbstractService(Guid userId) { this._userId = userId; }
    }
}
