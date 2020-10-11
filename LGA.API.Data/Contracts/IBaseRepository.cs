using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LGA.API.Model;

namespace LGA.API.Data.Contracts
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        int Count();
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
