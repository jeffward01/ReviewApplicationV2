using ReviewApplication.CORE.Domain;
using ReviewApplication.CORE.Repository;
using ReviewApplication.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.DATA.Repository
{
    public class ReviewPostRepository : Repository<ReviewPost>, IReviewPostRepository
    {
        public ReviewPostRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }
    }
}
