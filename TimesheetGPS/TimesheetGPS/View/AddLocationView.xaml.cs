using Autofac;
using System;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using TimesheetGPS.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TimesheetGPS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLocationView : ContentPage
    {
        private AddLocationViewModel vm;

        public AddLocationView()
        {
            vm = new AddLocationViewModel(App.container.Resolve<IEntityController<Locatie>>());

            BindingContext = vm;

            InitializeComponent();

            var position = new Position(52.048565, 5.095628);

            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMeters(400)));

            myMap.MapTapped += MyMap_MapTapped;
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            vm.Add();

            await Navigation.PopAsync(true);
        }

        private void MyMap_MapTapped(object sender, MapTappedEventArgs e)
        {
            var newPin = new CustomPin() { Label = "Test", Position = e.Position, Radius = vm.Radius };

            myMap.Pins.Clear();
            myMap.CustomPins.Clear();

            myMap.Pins.Add(newPin);
            myMap.CustomPins.Add(newPin);

            myMap.OnUpdateCircles(null);

            vm.Position = e.Position;
        }
    }
}