using System;
using System.Collections.Generic;
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

        private List<LocatieDisplayInfo> locaties;

        public LocatiesViewModel(IEntityController<Locatie> locatieController, IEntityController<Registratie> registratieController)
        {
            this.locatieController = locatieController;
            this.registratieController = registratieController;

            GetLocaties();
        }

        private void GetLocaties()
        {
            Locaties = locatieController
                          .Get()
                          .Select(x => new LocatieDisplayInfo
                          {
                              ID = x.Id,
                              Naam = x.Naam,
                              NumberOfRegistrations = registratieController.Get().Where(y => y.LocatieID == x.Id).Count(),
                              IsCurrentlyActive = registratieController.Get().Any(y => y.LocatieID == x.Id && y.EindTijd == null)
                          })
                          .ToList();
        }
        
        public List<LocatieDisplayInfo> Locaties
        {
            get { return locaties; }
            set
            {
                locaties = value;
                OnPropertyChanged("Locaties");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            GetLocaties();
        }
    }
}
