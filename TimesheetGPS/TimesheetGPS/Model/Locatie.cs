using Xamarin.Forms.Maps;

namespace TimesheetGPS.Model
{
    public class Locatie : Entity
    {
        public string Naam { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
