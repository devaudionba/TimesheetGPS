using Autofac;
using System;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using TimesheetGPS.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TimesheetGPS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocatieView : ContentPage
    {
        private LocatieViewModel vm;

        public LocatieView(int ID)
        {
            InitializeComponent();

            vm = new LocatieViewModel(App.container.Resolve<IEntityController<Locatie>>(),
                                      App.container.Resolve<IEntityController<Registratie>>());
            vm.Load(ID);

            myMap.Pins.Add(new Pin() { Label = vm.Naam, Position = vm.Position });
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(vm.Position, new Distance(100)));

            BindingContext = vm;
        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            vm.AddRegistratie(new Model.Registratie()
            {
                LocatieID = vm.ID,
                StartTijd = DateTime.Now,
                GPSRegistratie = false                 
            });
        }

        private void ButtonStop_Clicked(object sender, EventArgs e)
        {
            vm.StopRegistratie();
        }
    }
}