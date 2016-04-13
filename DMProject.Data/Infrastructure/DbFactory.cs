using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMProject.Data;

namespace DMProject.Data.Infrastructure
{
    public class DbFactory: Disposable, IDbFactory
    {
        DMProjectContext dbContext;
        public DMProjectContext Init() {
            return dbContext ?? (dbContext = new DMProjectContext());
        }

         protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
