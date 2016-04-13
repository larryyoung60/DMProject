using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DMProject.Entities;
using DMProject.Data.Infrastructure;
using DMProject.Data.Repositories;
using DMProject.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace DMProject.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private DMProjectContext dataContext;

        protected IDbFactory DbFactory { get; private set; }

        protected DMProjectContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        public EntityBaseRepository(IDbFactory DbFactory)
        {
            this.DbFactory = DbFactory;
        }
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }
        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.id == id);
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }
        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

    }
}
