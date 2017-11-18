using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;
using TimesheetGPS.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimesheetGPS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocatieView : ContentPage
    {
        private LocatieViewModel vm;

        public LocatieView(int ID)
        {
            vm = new LocatieViewModel(ID, App.container.Resolve<IRegistratieRepository>());
            BindingContext = vm;

            InitializeComponent();
        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            vm.AddRegistratie(new Model.Registratie()
            {
                LocatieID = vm.LocatieID,
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