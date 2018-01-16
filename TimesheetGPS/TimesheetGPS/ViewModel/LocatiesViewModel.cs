using System.Collections.Generic;
using System.Linq;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;

namespace TimesheetGPS.ViewModel
{
    public class LocatiesViewModel
    {
        private LocatieController locatieController = new LocatieController();
        private RegistratieController registratieController = new RegistratieController();

        public List<LocatieDisplayInfo> Locaties
        {
            get
            {
                var result = locatieController
                            .Get()
                            .Select(x => new LocatieDisplayInfo
                            {
                                ID = x.Id,
                                Naam = x.Naam,
                                NumberOfRegistrations = registratieController.Get().Where(y => y.LocatieID == x.Id).Count(),
                                IsCurrentlyActive = registratieController.Get().Any(y => y.LocatieID == x.Id && y.EindTijd == null)
                            })
                            .ToList();
                return result;
            }
        }
    }
}
