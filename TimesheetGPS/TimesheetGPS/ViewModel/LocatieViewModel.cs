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
        private IRegistratieRepository registratieRepository;
        private ILocatieRepository locatieRepository;

        private int id;
        private string naam;

        internal LocatieViewModel(IRegistratieRepository registratieRepository,
                                ILocatieRepository locatieRepository)
        {
            this.locatieRepository = locatieRepository;
            this.registratieRepository = registratieRepository;

        }

        internal void Load(int ID)
        {
            var locatie = this.locatieRepository.GetItem(ID);
            this.ID = locatie.ID;
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

        public List<Registratie> Registraties => registratieRepository.GetList(ID).OrderByDescending(x => x.StartTijd).ToList();

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddRegistratie(Registratie registratie)
        {
            registratieRepository.Add(registratie);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Registraties"));
                PropertyChanged(this, new PropertyChangedEventArgs("IsStartEnabled"));
                PropertyChanged(this, new PropertyChangedEventArgs("IsStopEnabled"));
            }
        }

        internal void StopRegistratie()
        {
            var activeRegistration = registratieRepository.GetList(ID).FirstOrDefault(x => x.EindTijd == null);
            if (activeRegistration == null)
            {
                // valt niet te stoppen
            }
            else
            {
                activeRegistration.EindTijd = DateTime.Now;
                registratieRepository.Update(activeRegistration);

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
