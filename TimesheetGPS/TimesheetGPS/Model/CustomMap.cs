using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace TimesheetGPS.Model
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }

        public event MapTappedEventHandler MapTapped;

        public delegate void MapTappedEventHandler(object sender, MapTappedEventArgs e);

        public void OnMapTapped(MapTappedEventArgs e)
        {
            if (MapTapped != null)
                MapTapped(this, e);
        }
    }

    public class MapTappedEventArgs : EventArgs
    {
        public MapTappedEventArgs(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; set; }
    }
}
