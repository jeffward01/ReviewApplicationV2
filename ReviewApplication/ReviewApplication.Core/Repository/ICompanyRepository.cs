using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Infrastructure;

namespace ReviewApplication.Core.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    { }
}
