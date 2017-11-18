using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Model;

namespace TimesheetGPS.Interfaces
{
    interface IRegistratieRepository : IRepository<Registratie>
    {
        List<Registratie> GetList(int locatieID);
    }
}
