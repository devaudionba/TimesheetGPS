using Autofac;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using TimesheetGPS.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimesheetGPS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocatiesView : ContentPage
    {
        private LocatiesViewModel vm;

        public LocatiesView()
        {
            vm = new LocatiesViewModel(App.container.Resolve<IEntityController<Locatie>>(), 
                                       App.container.Resolve<IEntityController<Registratie>>());
            BindingContext = vm;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void LocatiesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var locatie = e.Item as LocatieDisplayInfo;
            Navigation.PushAsync(new LocatieView(locatie.ID.Value));
        }
    }
}