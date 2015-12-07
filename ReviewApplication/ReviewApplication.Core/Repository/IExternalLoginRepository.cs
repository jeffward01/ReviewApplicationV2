using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Repository
{
    public interface IExternalLoginRepository : IRepository<ExternalLogin>
    {
    }
}
