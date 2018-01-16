using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetGPS.Model
{
    public class LocatieDisplayInfo
    {
        private int? id;
        private string naam;
        private int numberOfRegistrations;
        
        public int? ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public int NumberOfRegistrations
        {
            get { return numberOfRegistrations; }
            set { numberOfRegistrations = value; }
        }

        private bool isCurrentlyActive;

        public bool IsCurrentlyActive
        {
            get { return isCurrentlyActive; }
            set { isCurrentlyActive = value; }
        }

    }
}
