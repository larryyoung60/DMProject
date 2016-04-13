using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMProject.Data;

namespace DMProject.Data.Infrastructure
{
    public interface IDbFactory: IDisposable
    {
        DMProjectContext Init();
    }
}
