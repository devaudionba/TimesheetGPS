using Autofac;
using Plugin.Geofencing;
using SQLite;
using System;
using System.Linq;
using System.Reflection;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using TimesheetGPS.View;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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

            builder.RegisterGeneric(typeof(EntityController<>))
                   .As(typeof(IEntityController<>))
                   .InstancePerLifetimeScope();

            container = builder.Build();

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
            AppCenter.Start("ios=c9f5ef06-26e7-4e66-8f7f-d122adb66eff;" +
                   "android=c9f5ef06-26e7-4e66-8f7f-d122adb66eff",
                   typeof(Analytics), typeof(Crashes));

            // Start monitoring all locations
            var locatieController = App.container.Resolve<IEntityController<Locatie>>();
            var locaties = locatieController.Get();

            CrossGeofences.Current.StopAllMonitoring();
            foreach (var locatie in locaties)
            {
                var region = new GeofenceRegion(
                    locatie.Id.ToString(),
                    new Position(locatie.Latitude, locatie.Longitude),
                    Distance.FromKilometers(locatie.Radius)
                );

                CrossGeofences.Current.StartMonitoring(region);
            }

            CrossGeofences.Current.RegionStatusChanged += (sender, args) =>
            {
                var locatie = locatieController.Get().Where(l => l.Id.ToString() == args.Region.Identifier);
                var registratieController = App.container.Resolve<IEntityController<Registratie>>();

                switch (args.Status)
                {
                    case GeofenceStatus.Unknown:
                        break;

                    case GeofenceStatus.Entered:
                        registratieController.Add(new Model.Registratie()
                        {
                            LocatieID = int.Parse(args.Region.Identifier),
                            StartTijd = DateTime.Now,
                            GPSRegistratie = true
                        });

                        break;

                    case GeofenceStatus.Exited:
                        var activeRegistration = registratieController.Get()
                                .Where(x => x.LocatieID.ToString() == args.Region.Identifier)
                                .FirstOrDefault(x => x.EindTijd == null);

                        if (activeRegistration == null)
                            // TODO zou niet moeten kunnen, netjes fixen
                            break;

                        activeRegistration.EindTijd = DateTime.Now;
                        registratieController.Update(activeRegistration);
                        break;

                    default:
                        break;
                }
            };
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
