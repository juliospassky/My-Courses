using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace GTSharp.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntitie, TId>
        where TEntitie : class
        where TId : struct
    {
        bool Exist(Func<TEntitie, bool> where);

        #region Lists
        IQueryable<TEntitie> List(params Expression<Func<TEntitie, object>>[] includeProperties);

        IQueryable<TEntitie> ListBy(Expression<Func<TEntitie, bool>> where, params Expression<Func<TEntitie, object>>[] includeProperties);

        IQueryable<TEntitie> ListBySort<TKey>(Expression<Func<TEntitie, TKey>> order, bool ascendant = true, params Expression<Func<TEntitie, object>>[] includeProperties);

        IQueryable<TEntitie> ListBySortWhere<TKey>(Expression<Func<TEntitie, bool>> where, Expression<Func<TEntitie, TKey>> order, bool ascendant = true, params Expression<Func<TEntitie, object>>[] includeProperties);
        #endregion

        #region Gets
        TEntitie GetBy(Func<TEntitie, bool> where, params Expression<Func<TEntitie, object>>[] includeProperties);

        TEntitie GetById(TId id, params Expression<Func<TEntitie, object>>[] includeProperties);
        #endregion

        #region CRUD
        TEntitie Add(TEntitie entitie);

        IEnumerable<TEntitie> AddList(IEnumerable<TEntitie> entities);

        TEntitie Update(TEntitie entitie);

        void Remove(TEntitie entitie);
        #endregion
    }
}
