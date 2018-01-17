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
    public class LocatieViewModel : INotifyPropertyChanged
    {
        private IEntityController<Locatie> locatieController;
        private IEntityController<Registratie> registratieController;

        private int id;
        private string naam;

        public LocatieViewModel(IEntityController<Locatie> locatieController, IEntityController<Registratie> registratieController)
        {
            this.locatieController = locatieController;
            this.registratieController = registratieController;
        }

        internal void Load(int ID)
        {
            var locatie = this.locatieController.Get(ID);
            this.ID = locatie.Id.Value;
            this.Naam = locatie.Naam;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Naam
        {
            get { return naam; }
            set
            {
                naam = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Naam"));
                }
            }
        }

        public bool IsStartEnabled => !Registraties.Any(x => x.EindTijd == null);

        public bool IsStopEnabled => !IsStartEnabled;

        public List<Registratie> Registraties => registratieController.Get().Where(x => x.LocatieID == ID).OrderByDescending(x => x.StartTijd).ToList();

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddRegistratie(Registratie registratie)
        {
            registratieController.Add(registratie);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Registraties"));
                PropertyChanged(this, new PropertyChangedEventArgs("IsStartEnabled"));
                PropertyChanged(this, new PropertyChangedEventArgs("IsStopEnabled"));
            }
        }

        internal void StopRegistratie()
        {
            var activeRegistration = registratieController.Get().Where(x => x.LocatieID == ID).FirstOrDefault(x => x.EindTijd == null);
            if (activeRegistration == null)
            {
                // valt niet te stoppen
            }
            else
            {
                activeRegistration.EindTijd = DateTime.Now;
                registratieController.Update(activeRegistration);

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Registraties"));
                    PropertyChanged(this, new PropertyChangedEventArgs("IsStartEnabled"));
                    PropertyChanged(this, new PropertyChangedEventArgs("IsStopEnabled"));
                }

            }
        }
    }
}
