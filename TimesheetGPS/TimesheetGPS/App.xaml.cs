using Autofac;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using TimesheetGPS.View;
using Xamarin.Forms;

namespace TimesheetGPS
{
    public partial class App : Application
    {
        public static IContainer container;

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

            MainPage = new NavigationPage(new Locaties());
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
