using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;

namespace TimesheetGPS.Model
{
    public class LocatieRepository : IRepository<Locatie>
    {
        private List<Locatie> locaties = new List<Locatie>()
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

        public void Add(Locatie item)
        {
            locaties.Add(item);
        }

        public Locatie GetItem(int ID)
        {
            return locaties.Where(x => x.ID == ID).FirstOrDefault();
        }

        public List<Locatie> GetList()
        {
            return locaties;
        }
    }
}
