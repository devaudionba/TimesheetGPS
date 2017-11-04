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
        public List<Locatie> Locaties
        {
            get
            {
                return new List<Locatie>()
                {
                    new Locatie()
                    {
                        IsCurrentlyActive = false,
                        ID = 1,
                        Naam = "SVB"
                    },
                    new Locatie()
                    {
                        IsCurrentlyActive = true,
                        ID = 2,
                        Naam = "Thuis"
                    },
                    new Locatie()
                    {
                        IsCurrentlyActive = false,
                        ID = 3,
                        Naam = "Basketball"
                    }
                };
            }
        }
    }
}
