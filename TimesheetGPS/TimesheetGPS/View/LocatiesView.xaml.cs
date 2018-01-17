using Autofac;
using System;
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

            var addToolbarItem = new ToolbarItem();
            addToolbarItem.Text = "Add";
            //addToolbarItem.Command = new Command(() => { vm.Locaties.Add(new Locatie() {  Naam = "Test", Id = 4})); });


            //var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
            //deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            //deleteAction.Clicked += async (sender, e) => {
            //    var mi = ((MenuItem)sender);
            //};
            //// add to the ViewCell's ContextActions property
            //ContextActions.Add(moreAction);
            //ContextActions.Add(deleteAction);



            ToolbarItems.Add(addToolbarItem);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.Refresh();
        }

        private void LocatiesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var locatie = e.Item as LocatieDisplayInfo;
            Navigation.PushAsync(new LocatieView(locatie.ID.Value));
        }
        public async System.Threading.Tasks.Task OnDeleteAsync(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = (LocatieDisplayInfo)mi.CommandParameter;

            var result = await DisplayAlert($"Delete location '{item.Naam}'?", " Are you sure you want to delete this?", "OK", "Cancel");

            if (result)
                vm.Delete(item);
        }

    }
}