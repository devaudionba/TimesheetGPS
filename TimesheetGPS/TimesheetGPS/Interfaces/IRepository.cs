using System.Collections.Generic;

namespace TimesheetGPS.Interfaces
{
    public interface IRepository<T>
    {
        T GetItem(int ID);

        List<T> GetList();

        void Add(T item);

        void Update(T item);
    }
}
