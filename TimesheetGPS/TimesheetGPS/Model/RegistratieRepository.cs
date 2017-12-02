using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Interfaces;
using SQLite;

namespace TimesheetGPS.Model
{
     public class RegistratieRepository : IRegistratieRepository
    {
        private List<Registratie> registraties;

        public List<Registratie> Registraties
        {
            get { return registraties; }
            set
            {
                registraties = value;
            }
        }


        public RegistratieRepository()
        {
            registraties = App.Database.GetRegistraties().Result;
        }

        public void Add(Registratie item)
        {
            registraties.Add(item);
            App.Database.SaveItemAsync(item);
        }

        public void Update(Registratie item)
        {
            App.Database.SaveItemAsync(item);
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
