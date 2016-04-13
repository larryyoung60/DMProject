using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Data.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private DMProjectContext dbContext;
        private readonly IDbFactory dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DMProjectContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
