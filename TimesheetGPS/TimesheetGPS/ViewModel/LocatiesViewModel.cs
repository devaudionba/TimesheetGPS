using System.Collections.Generic;
using System.Linq;
using TimesheetGPS.Interfaces;
using TimesheetGPS.Model;

namespace TimesheetGPS.ViewModel
{
    public class LocatiesViewModel
    {
        private IEntityController<Locatie> locatieController;
        private IEntityController<Registratie> registratieController;

        public LocatiesViewModel(IEntityController<Locatie> locatieController, IEntityController<Registratie> registratieController)
        {
            this.locatieController = locatieController;
            this.registratieController = registratieController;
        }

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
