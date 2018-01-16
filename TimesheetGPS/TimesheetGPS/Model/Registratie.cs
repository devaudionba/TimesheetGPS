using SQLite;
using System;

namespace TimesheetGPS.Model
{
    [Table("Registratie")]
    public class Registratie : Entity
    {
        public int LocatieID { get; set; }

        private DateTime startTijd;
        public DateTime StartTijd
        {
            get { return startTijd; }
            set
            {
                if (value.Equals(startTijd))
                {
                    return;
                }
                startTijd = value;
                OnPropertyChanged();
            }
        }

        private DateTime? eindTijd;
        public DateTime? EindTijd
        {
            get { return eindTijd; }
            set
            {
                if (value.Equals(eindTijd))
                {
                    return;
                }
                eindTijd = value;
                OnPropertyChanged();
            }
        }

        private bool gpsRegistratie;
        public bool GPSRegistratie
        {
            get { return gpsRegistratie; }
            set
            {
                if (value.Equals(gpsRegistratie))
                {
                    return;
                }
                gpsRegistratie = value;
                OnPropertyChanged();
            }
        }
    }
}
