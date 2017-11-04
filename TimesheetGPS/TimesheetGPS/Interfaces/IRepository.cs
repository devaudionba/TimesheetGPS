using System.Collections.Generic;

namespace TimesheetGPS.Interfaces
{
    interface IRepository<T>
    {
        T GetItem(int ID);

        List<T> GetList();
    }
}
