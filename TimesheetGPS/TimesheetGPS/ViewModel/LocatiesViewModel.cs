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

        public LocatiesViewModel(IRegistratieRepository registratieRepository,
                                   ILocatieRepository locatieRepository)
        {
            this.locatieRepository = locatieRepository;
            this.registratieRepository = registratieRepository;
        }

        public List<LocatieDisplayInfo> Locaties
        {
            get
            {
                var result = locatieRepository
                            .GetList()
                            .Select(x => new LocatieDisplayInfo
                            {
                                ID = x.ID,
                                Naam = x.Naam,
                                NumberOfRegistrations = registratieRepository.GetList(x.ID).Count(),
                                IsCurrentlyActive = registratieRepository.GetList(x.ID).Any(r => r.EindTijd == null)
                            })
                            .ToList();
                return result;
            }
        }
    }
}
