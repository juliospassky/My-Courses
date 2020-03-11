using System;
using System.Linq.Expressions;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return o => o.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return o => o.User == user && o.Done == true;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUnDone(string user)
        {
            return o => o.User == user && o.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return o => 
                o.User == user &&
                o.Done == done &&
                o.Date.Date == date;
        }
    }
}