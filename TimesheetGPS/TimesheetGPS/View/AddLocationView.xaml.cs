using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Instravu",
                Address = "Middelhoeve 20"
            };
            myMap.CustomPins = new List<CustomPin> { pin };
            myMap.Pins.Add(pin);

            myMap.MapTapped += MyMap_MapTapped;
        }

        private void MyMap_MapTapped(object sender, MapTappedEventArgs e)
        {
            var newPin = new CustomPin() { Label = "Test", Position = e.Position };
            myMap.Pins.Clear();
            myMap.CustomPins.Clear();
            myMap.Pins.Add(newPin);
            myMap.CustomPins.Add(newPin);

            vm.Position = e.Position;
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            vm.Add();

            await Navigation.PopAsync(true);
        }
    }
}