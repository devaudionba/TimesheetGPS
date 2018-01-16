//using System.IO;
//using TimesheetGPS.Droid;
//using TimesheetGPS.Interfaces;
//using Xamarin.Forms;

//[assembly: Dependency(typeof(FileHelper_Android))]
//namespace TimesheetGPS.Droid
//{
//    public class FileHelper_Android : IFileHelper
//    {
//        public string GetLocalFilePath(string filename)
//        {
//            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//            return Path.Combine(path, filename);
//        }
//    }
//}