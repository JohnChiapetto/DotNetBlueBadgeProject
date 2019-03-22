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

        public AbstractService(Guid userId) {
            if (Context == null)
                Context = new ApplicationDbContext();
            this._userId = userId;
        }
    }
}
