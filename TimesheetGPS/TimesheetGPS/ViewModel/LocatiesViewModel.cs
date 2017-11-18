using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;

namespace TimesheetGPS.ViewModel
{
    public class LocatiesViewModel
    {
        private ILocatieRepository locatieRepository;
        private IRegistratieRepository registratieRepository;

        internal LocatiesViewModel(IRegistratieRepository registratieRepository,
                                   ILocatieRepository locatieRepository)
        {
            this.locatieRepository = locatieRepository;
            this.registratieRepository = registratieRepository;
        }

        public List<Locatie> Locaties
        {
            get
            {
                return locatieRepository.GetList();
            }
        }

        public int NumberOfRegistrations => registratieRepository.GetList().Count();
    }
}
