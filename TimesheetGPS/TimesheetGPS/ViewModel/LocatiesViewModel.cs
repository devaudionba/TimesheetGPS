using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Model;

namespace TimesheetGPS.ViewModel
{
    public class LocatiesViewModel
    {
        LocatieRepository repo;

        public LocatiesViewModel()
        {
            repo = new LocatieRepository();
        }

        public List<Locatie> Locaties
        {
            get
            {
                return repo.GetList();
            }
        }
    }
}
