using Autofac;
using SQLite;
using System;
using System.Reflection;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using TimesheetGPS.View;
using Xamarin.Forms;

namespace TimesheetGPS
{
    public partial class App : Application
    {
        public static IContainer container;
        static SQLiteConnection sqlConnection;

        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();

            //builder.RegisterInstance(new RegistratieController())
            //    .As<RegistratieController>()
            //    .ExternallyOwned;

            //builder.RegisterGeneric(typeof(EntityController<>))
            //    .As(typeof(IEntityController<>))
            //    .InstancePerLifetimeScope();


            //builder.RegisterAssemblyTypes(typeof(IEntityController<>));

            //builder.RegisterAssemblyTypes(App.Current.asse).AsClosedTypesOf(typeof(IEntityController<>));

            //var dataAccess = Assembly.GetExecutingAssembly()

            //var controllerOpenGenericType = typeof(IEntityController<>);
            //var controllerImplementations = basePathAssemblies.

            //builder.RegisterInstance(new RegistratieController())
            //       .As<IRegistratieRepository>()
            //       .ExternallyOwned();

            //builder.RegisterInstance(new LocatieRepository())
            //       .As<ILocatieRepository>()
            //       .ExternallyOwned();

            //container = builder.Build();

            MainPage = new NavigationPage(new LocatiesView());
        }

        public static SQLiteConnection SqlConnection
        {
            get
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        sqlConnection = DependencyService.Get<IDatabaseAccess>().GetConnection();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return sqlConnection;
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
