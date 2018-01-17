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

            myMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                new Position(37, -122), Distance.FromMiles(1)));
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            vm.Add();

            await Navigation.PopModalAsync(true);
        }
    }
}