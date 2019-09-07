using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GTSharp.Domain.Entities.Base;
using GTSharp.Domain.Interfaces.Repositories.Base;

namespace GTSharp.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntitie, TId> : IRepositoryBase<TEntitie, TId>
        where TEntitie : EntityBase
        where TId : struct
    {

        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public TEntitie Add(TEntitie entitie)
        {
            return _context.Set<TEntitie>().Add(entitie);
        }

        public IEnumerable<TEntitie> AddList(IEnumerable<TEntitie> entities)
        {
            return _context.Set<TEntitie>().AddRange(entities);
        }

        public bool Exist(Func<TEntitie, bool> where)
        {
            return _context.Set<TEntitie>().Any(where);
        }

        public TEntitie GetBy(Func<TEntitie, bool> where, params Expression<Func<TEntitie, object>>[] includeProperties)
        {
            return List(includeProperties).FirstOrDefault(where);
        }

        public TEntitie GetById(TId id, params Expression<Func<TEntitie, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntitie>().Find(id);
        }

        public IQueryable<TEntitie> List(params Expression<Func<TEntitie, object>>[] includeProperties)
        {
            IQueryable<TEntitie> query = _context.Set<TEntitie>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntitie>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntitie> ListBy(Expression<Func<TEntitie, bool>> where, params Expression<Func<TEntitie, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        public IQueryable<TEntitie> ListBySort<TKey>(Expression<Func<TEntitie, TKey>> order, bool ascendant = true, params Expression<Func<TEntitie, object>>[] includeProperties)
        {
            return ascendant ? List(includeProperties).OrderBy(order) : List(includeProperties).OrderByDescending(order);
        }

        public IQueryable<TEntitie> ListBySortWhere<TKey>(Expression<Func<TEntitie, bool>> where, Expression<Func<TEntitie, TKey>> order, bool ascendant = true, params Expression<Func<TEntitie, object>>[] includeProperties)
        {
            return ascendant ? ListBy(where, includeProperties).OrderBy(order) : ListBy(where, includeProperties).OrderByDescending(order);

        }

        public void Remove(TEntitie entitie)
        {
            _context.Set<TEntitie>().Remove(entitie);
        }

        public TEntitie Update(TEntitie entitie)
        {
            _context.Entry(entitie).State = EntityState.Modified;

            return entitie;
        }

        private IQueryable<TEntitie> Include(IQueryable<TEntitie> query, params Expression<Func<TEntitie, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
