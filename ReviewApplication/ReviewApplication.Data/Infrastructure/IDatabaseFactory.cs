using ReviewApplication.Core.Infrastructure;
using ReviewApplication.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ReviewApplicationDbContext GetDataContext();
    }
}
