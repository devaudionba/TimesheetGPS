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
        private Locatie locatie;
        private IRegistratieRepository registratieRepository;

        internal LocatieViewModel(int ID, IRegistratieRepository registratieRepository)
        {
            var locatieRepo = new LocatieRepository();
            locatie = locatieRepo.GetItem(ID);

            this.registratieRepository = registratieRepository;
        }

        public int LocatieID => locatie.ID;

        public string Naam => locatie.Naam;

        public bool IsCurrentlyActive => registratieRepository.GetList(locatie.ID).Count(x => x.EindTijd == null) > 0;

        public List<Registratie> Registraties => registratieRepository.GetList(locatie.ID).OrderByDescending(x => x.StartTijd).ToList();

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddRegistratie(Registratie registratie)
        {
            registratieRepository.Add(registratie);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Registraties"));
            }
        }

        internal void StopRegistratie()
        {
            var activeRegistration = registratieRepository.GetList(locatie.ID).FirstOrDefault(x => x.EindTijd == null);
            if (activeRegistration == null)
            {
                // valt niet te stoppen
            }
            else
            {
                activeRegistration.EindTijd = DateTime.Now;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Registraties"));
                }

            }
        }
    }
}
