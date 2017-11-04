using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimesheetGPS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Locaties : ContentPage
    {
        private LocatiesViewModel vm;

        public Locaties()
        {
            InitializeComponent();
            vm = new LocatiesViewModel();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}