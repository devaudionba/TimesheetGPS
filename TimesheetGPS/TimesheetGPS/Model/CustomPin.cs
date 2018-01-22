using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace TimesheetGPS.Model
{
    public class CustomPin : Pin
    {
        public double Radius { get; set; } = 100;
    }
}
