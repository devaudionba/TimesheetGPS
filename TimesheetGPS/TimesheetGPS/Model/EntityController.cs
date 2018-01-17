using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using TimesheetGPS.Interfaces;

namespace TimesheetGPS.Model
{
    public class EntityController<T> : IEntityController<T> where T : Entity, new()
    {
        private SQLiteConnection db;

        public EntityController()
        {
            this.db = App.SqlConnection;

            App.SqlConnection.CreateTable<Registratie>();
        }

        public int Add(T entity)
        {
            return db.Insert(entity);
        }

        public TableQuery<T> AsQueryable()
        {
            return db.Table<T>();
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            var query = db.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.Count();
        }

        public List<T> Get()
        {
            return db.Table<T>().ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return db.Find<T>(predicate);
        }

        public T Get(int id)
        {
            return db.Find<T>(id);
        }

        public ObservableCollection<T> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = query.OrderBy<TValue>(orderBy);
            }

            var collection = new ObservableCollection<T>();
            var items = query.ToList();
            foreach (var item in items)
            {
                collection.Add(item);
            }

            return collection;
        }

        public int Remove(int id)
        {
            return db.Delete<Locatie>(id);
        }
        public int Update(T entity)
        {
            return db.Update(entity);
        }
    }
}