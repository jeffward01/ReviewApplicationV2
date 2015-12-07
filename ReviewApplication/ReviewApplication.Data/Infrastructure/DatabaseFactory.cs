using ReviewApplication.CORE.Domain;
using ReviewApplication.CORE.Infrastructure;
using ReviewApplication.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.DATA.Infrastructure
{
    /// <summary>
    /// Responsible for creating a DataContext that will live for a certain amount time.
    /// </summary>
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly ReviewApplicationDbContext _dataContext;

        public ReviewApplicationDbContext GetDataContext()
        {
            return _dataContext ?? new ReviewApplicationDbContext();
        }

        public DatabaseFactory()
        {
            _dataContext = new ReviewApplicationDbContext();
        }

        protected override void DisposeCore()
        {
            if(_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }
    }
}
