using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Model;

namespace TimesheetGPS.ViewModel
{
    public class LocatieViewModel
    {
        private Locatie locatie;

        public LocatieViewModel(int ID)
        {
            var repo = new LocatieRepository();
            locatie = repo.GetItem(ID);
        }
        public string Naam => locatie.Naam;

        public bool IsCurrentlyActive => locatie.IsCurrentlyActive;
    }
}
