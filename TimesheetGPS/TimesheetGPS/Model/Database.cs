//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TimesheetGPS.Model
//{
//    public class Database
//    {
//        readonly SQLiteAsyncConnection database;

//        public Database(string dbPath)
//        {
//            try
//            {
//                database = new SQLiteAsyncConnection(dbPath);
//                database.CreateTableAsync<Registratie>().Wait();
//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public Task<List<T>> GetItems<T>() where T : IRecord
//        {
//            return database.Table<nameof(T)>().ToListAsync();
//        }

//        public Task<int> SaveItemAsync<T>(T item) where T : IRecord
//        {
//            if (item.ID != 0)
//            {
//                return database.UpdateAsync(item);
//            }
//            else
//            {
//                return database.InsertAsync(item);
//            }
//        }

//    }
//}
