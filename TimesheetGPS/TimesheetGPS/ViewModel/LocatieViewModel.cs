using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Model;

namespace TimesheetGPS.ViewModel
{
    public class LocatieViewModel : INotifyPropertyChanged
    {
        private Locatie locatie;
        private RegistratieRepository registratieRepo;

        public LocatieViewModel(int ID)
        {
            var locatieRepo = new LocatieRepository();
            locatie = locatieRepo.GetItem(ID);

            registratieRepo = new RegistratieRepository();
        }

        public int LocatieID => locatie.ID;

        public string Naam => locatie.Naam;

        public bool IsCurrentlyActive => locatie.IsCurrentlyActive;

        public List<Registratie> Registraties => registratieRepo.GetList(locatie.ID).OrderByDescending(x => x.StartTijd).ToList();

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddRegistratie(Registratie registratie)
        {
            registratieRepo.Add(registratie);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Registraties"));
            }
        }
    }
}
