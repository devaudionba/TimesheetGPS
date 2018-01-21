using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace TimesheetGPS.Model
{
    public class CustomMap : Map
    {
        private List<CustomPin> customPins = new List<CustomPin>();

        public delegate void MapTappedEventHandler(object sender, MapTappedEventArgs e);
        public delegate void UpdateCirclesEventHandler(object sender, UpdateCirclesEventArgs e);

        public event MapTappedEventHandler MapTapped;
        public event UpdateCirclesEventHandler UpdateCircles;

        public List<CustomPin> CustomPins
        {
            get { return customPins; }
            set
            {
                customPins = value;
            }
        }

        public void OnMapTapped(MapTappedEventArgs e)
        {
            MapTapped?.Invoke(this, e);
        }

        public void OnUpdateCircles(UpdateCirclesEventArgs e)
        {
            UpdateCircles?.Invoke(this, e);
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

    public class UpdateCirclesEventArgs : EventArgs
    {
    }
}