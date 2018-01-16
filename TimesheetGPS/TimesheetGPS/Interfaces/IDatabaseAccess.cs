using SQLite;

namespace TimesheetGPS.Interfaces
{
    public interface IDatabaseAccess
    {
        SQLiteConnection GetConnection();
    }
}
