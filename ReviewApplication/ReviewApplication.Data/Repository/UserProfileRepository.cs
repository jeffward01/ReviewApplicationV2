using ReviewApplication.Data.Infrastructure;
using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Repository;
using ReviewApplication.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }

    }
}
