using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;

namespace TimesheetGPS.ViewModel
{
    public class LocatiesViewModel : INotifyPropertyChanged
    {
        private IEntityController<Locatie> locatieController;
        private IEntityController<Registratie> registratieController;

        private ObservableCollection<LocatieDisplayInfo> locaties;

        public LocatiesViewModel(IEntityController<Locatie> locatieController, IEntityController<Registratie> registratieController)
        {
            this.locatieController = locatieController;
            this.registratieController = registratieController;

            GetLocaties();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<LocatieDisplayInfo> Locaties
        {
            get { return locaties; }
            set
            {
                locaties = value;
                OnPropertyChanged("Locaties");
            }
        }

        public void Refresh()
        {
            GetLocaties();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GetLocaties()
        {
            Locaties = new ObservableCollection<LocatieDisplayInfo>(locatieController
                          .Get()
                          .Select(x => new LocatieDisplayInfo
                          {
                              ID = x.Id,
                              Naam = x.Naam,
                              NumberOfRegistrations = registratieController.Get().Where(y => y.LocatieID == x.Id).Count(),
                              IsCurrentlyActive = registratieController.Get().Any(y => y.LocatieID == x.Id && y.EindTijd == null)
                          })
                          .ToList());
        }

        public void Delete(LocatieDisplayInfo item)
        {
            locatieController.Remove(item.ID.Value);
            Refresh();
        }
    }
}