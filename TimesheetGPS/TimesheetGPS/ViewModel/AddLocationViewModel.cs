using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;

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
            locatieController.Add(new Locatie() { Naam = Name });
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
