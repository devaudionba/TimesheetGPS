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
        LocatieRepository repo;
        private IRegistratieRepository registratieRepository;

        internal LocatiesViewModel(IRegistratieRepository registratieRepository)
        {
            repo = new LocatieRepository();
            this.registratieRepository = registratieRepository;
        }

        public List<Locatie> Locaties
        {
            get
            {
                return repo.GetList();
            }
        }

        public int NumberOfRegistrations => registratieRepository.GetList().Count();
    }
}
