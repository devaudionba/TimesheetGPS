﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
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
            vm = new LocatiesViewModel(App.container.Resolve<IRegistratieRepository>());
            BindingContext = vm;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void LocatiesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var locatie = e.Item as Locatie;
            Navigation.PushAsync(new LocatieView(locatie.ID));
        }
    }
}