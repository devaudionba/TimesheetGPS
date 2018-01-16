using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetGPS.Model;

namespace TimesheetGPS.Model
{
    public class RegistratieController : EntityController<Registratie>
    {
        public RegistratieController() : base(App.SqlConnection)
        {
            App.SqlConnection.CreateTable<Registratie>();
        }
    }
}
