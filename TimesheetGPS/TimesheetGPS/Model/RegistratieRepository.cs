using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;

namespace TimesheetGPS.Model
{
    class RegistratieRepository : IRepository<Registratie>
    {
        private List<Registratie> registraties = new List<Registratie>()
                {
                    new Registratie()
                    {
                        ID = 1,
                        LocatieID = 1,
                        StartTijd = new DateTime(2017,11,1,9,1,12),
                        EindTijd = new DateTime(2017,11,1,17,28,42),
                        GPSRegistratie = false
                    },
                    new Registratie()
                    {
                        ID = 2,
                        LocatieID = 1,
                        StartTijd = new DateTime(2017,11,2,8,46,12),
//                        EindTijd = new DateTime(2017,11,2,16,57,42),
                        GPSRegistratie = false
                    },
                    new Registratie()
                    {
                        ID = 3,
                        LocatieID = 2,
                        StartTijd = new DateTime(2017,10,2,8,46,12),
                        EindTijd = new DateTime(2017,10,2,16,57,42),
                        GPSRegistratie = false
                    }
                };

        public void Add(Registratie item)
        {
            registraties.Add(item);
        }

        public Registratie GetItem(int ID)
        {
            return registraties.Where(x => x.ID == ID).FirstOrDefault();
        }

        public List<Registratie> GetList()
        {
            return registraties;
        }

        public List<Registratie> GetList(int locatieID)
        {
            return registraties.Where(x => x.LocatieID == locatieID).ToList();
        }
    }
}
