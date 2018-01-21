using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using Xamarin.Forms.Maps;

namespace TimesheetGPS.ViewModel
{
    class AddLocationViewModel : INotifyPropertyChanged
    {
        private IEntityController<Locatie> locatieController;

        public AddLocationViewModel(IEntityController<Locatie> locatieController)
        {
            this.locatieController = locatieController;
        }

        public void Add()
        {
            locatieController.Add(new Locatie() { Naam = Name, Latitude = Position.Latitude, Longitude = Position.Longitude });
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("IsEnabled");
            }
        }

        private Position position;

        public Position Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged("Position");
                OnPropertyChanged("IsEnabled");
            }
        }

        public bool IsEnabled => (Position != null) && (!string.IsNullOrEmpty(Name));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
