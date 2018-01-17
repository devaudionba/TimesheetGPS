using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimesheetGPS.Model;

namespace TimesheetGPS.Interfaces
{
    public interface IEntityController<T> where T : Entity, new()
    {
        List<T> Get();

        T Get(int id);

        ObservableCollection<T> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);

        T Get(Expression<Func<T, bool>> predicate);

        TableQuery<T> AsQueryable();

        int Add(T entity);

        int Update(T entity);

        int Remove(int id);

        int Count(Expression<Func<T, bool>> predicate = null);
    }
}
