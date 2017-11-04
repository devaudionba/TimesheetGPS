using System;

namespace TimesheetGPS.Model
{
    public class Registratie
    {
        public int ID { get; set; }
        public int LocatieID { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime? EindTijd { get; set; }
        public bool GPSRegistratie { get; set; }
    }
}
