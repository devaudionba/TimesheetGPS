using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetGPS.Model
{
    public class LocatieController : EntityController<Locatie>
    {
        public LocatieController() : base(App.SqlConnection)
        {
            App.SqlConnection.CreateTable<Locatie>();
        }
    }
}
