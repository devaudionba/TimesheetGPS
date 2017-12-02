using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetGPS.Model
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            try
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<Registratie>().Wait();
            }
            catch (Exception ex)
            {
            }
        }

        public Task<List<Registratie>> GetRegistraties()
        {
            return database.Table<Registratie>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Registratie item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

    }
}
