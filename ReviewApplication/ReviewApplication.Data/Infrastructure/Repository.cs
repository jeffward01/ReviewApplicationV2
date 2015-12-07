using ReviewApplication.CORE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ReviewApplication.Data.Infrastructure;
using System.Data.Entity;

namespace ReviewApplication.DATA.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ReviewApplicationDbContext _dataContext;
        protected ReviewApplicationDbContext DataContext
        {
            get
            {
                return _dataContext ?? (_dataContext = DatabaseFactory.GetDataContext());
            }
            set
            {
                _dataContext = value;
            }
        }

        protected IDatabaseFactory DatabaseFactory { get; }
        protected IDbSet<T> DbSet { get; set; }

        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            DbSet = DataContext.Set<T>();
        }

        public T Add(T entity)
        {
            return DbSet.Add(entity);
        }
        public bool Any(Expression<Func<T, bool>> condition)
        {
            return DbSet.Any(condition);
        }
        public int Count()
        {
            return DbSet.Count();
        }
        public int Count(Expression<Func<T, bool>> where)
        {
            return DbSet.Count(where);
        }
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return DbSet.FirstOrDefault(where);
        }
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
        public T GetByID(params object[] id)
        {
            return DbSet.Find(id);
        }
        public T Update(T entity)
        {
            DbSet.Attach(entity);

            DataContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return DbSet.Where(where);
        }
    }
}
