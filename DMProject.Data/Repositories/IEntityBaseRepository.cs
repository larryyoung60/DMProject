using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DMProject.Entities;

namespace DMProject.Data.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        T GetSingle(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);

    }
}
