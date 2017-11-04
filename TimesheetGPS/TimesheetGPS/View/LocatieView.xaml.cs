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
    public partial class LocatieView : ContentPage
    {
        public LocatieView(int ID)
        {
            var vm = new LocatieViewModel(ID);
            BindingContext = vm;

            InitializeComponent();
        }
    }
}