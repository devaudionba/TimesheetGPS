using Autofac;
using System;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using TimesheetGPS.View;
using Xamarin.Forms;

namespace TimesheetGPS
{
    public partial class App : Application
    {
        public static IContainer container;
        static Database database;

        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();

            builder.RegisterInstance(new RegistratieRepository())
                   .As<IRegistratieRepository>()
                   .ExternallyOwned();

            builder.RegisterInstance(new LocatieRepository())
                   .As<ILocatieRepository>()
                   .ExternallyOwned();

            container = builder.Build();

            MainPage = new NavigationPage(new LocatiesView());
        }

        public static Database Database
        {
            get
            {
                try
                {
                    if (database == null)
                    {
                        var path = DependencyService.Get<IFileHelper>().GetLocalFilePath("TimesheetGPS_SQLite.db3");
                        database = new Database(path);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
