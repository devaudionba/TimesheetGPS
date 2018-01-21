using System;
using System.ComponentModel;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;
using Xamarin.Forms.Maps;

namespace TimesheetGPS.ViewModel
{
    internal class AddLocationViewModel : INotifyPropertyChanged
    {
        private IEntityController<Locatie> locatieController;

        private string name;

        private Position position;

        private double radius;

        public AddLocationViewModel(IEntityController<Locatie> locatieController)
        {
            this.locatieController = locatieController;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsEnabled => (Position != null) && (!string.IsNullOrEmpty(Name));

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

        public double Radius
        {
            get { return Math.Max(radius, 25); }
            set
            {
                radius = Math.Max(value, 25);
                OnPropertyChanged("Radius");
            }
        }

        public void Add()
        {
            locatieController.Add(
                new Locatie()
                {
                    Naam = Name,
                    Latitude = Position.Latitude,
                    Longitude = Position.Longitude,
                    Radius = Radius
                });
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}