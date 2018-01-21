using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using TimesheetGPS.Droid;
using TimesheetGPS.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]

namespace TimesheetGPS.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        private GoogleMap customMap;

        private List<CustomPin> customPins;
        private List<Circle> circles;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                //if (customPin.Id == "Xamarin")
                //{
                //    view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
                //}
                //else
                //{
                view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                //}

                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                }

                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (customMap != null)
            {
                customMap.MapClick -= map_MapClick;
            }

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
                formsMap.UpdateCircles += FormsMap_UpdateCircles;

                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            customMap = map;

            if (customMap != null)
                customMap.MapClick += map_MapClick;

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);

            UpdateCircles();
        }

        private void FormsMap_UpdateCircles(object sender, UpdateCirclesEventArgs e)
        {
            UpdateCircles();
        }

        private CustomPin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }

        private void map_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            ((CustomMap)Element).OnMapTapped(new MapTappedEventArgs(new Position(e.Point.Latitude, e.Point.Longitude)));
        }

        private void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }

            // fill custom info window here
        }

        private void UpdateCircles()
        {
            circles?.ForEach(x => x.Remove());

            circles = new List<Circle>();

            customPins?.ForEach(x => {
                var circleOptions = new CircleOptions();
                circleOptions.InvokeCenter(new LatLng(x.Position.Latitude, x.Position.Longitude));
                circleOptions.InvokeRadius(x.Radius);
                circleOptions.InvokeFillColor(0X66FF0000);
                circleOptions.InvokeStrokeColor(0X66FF0000);
                circleOptions.InvokeStrokeWidth(0);

                circles.Add(NativeMap.AddCircle(circleOptions));
            });
        }
    }
}