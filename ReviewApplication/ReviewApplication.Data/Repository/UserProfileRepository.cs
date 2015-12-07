using ReviewApplication.DATA.Infrastructure;
using ReviewApplication.CORE.Domain;
using ReviewApplication.CORE.Repository;
using ReviewApplication.CORE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.DATA.Repository
{
    public class UserProfileRepository : Repository<User>, IUserRepository
    {
        public UserProfileRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }

    }
}
