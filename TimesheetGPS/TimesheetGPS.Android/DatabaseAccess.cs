using SQLite;
using TimesheetGPS.Droid;
using TimesheetGPS.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseAccess))]
namespace TimesheetGPS.Droid
{
    public class DatabaseAccess : IDatabaseAccess
    {
        public SQLiteConnection GetConnection()
        {
            var sqlDbFileName = "TimesheetGPS_SQLite.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentsPath, sqlDbFileName);

            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}