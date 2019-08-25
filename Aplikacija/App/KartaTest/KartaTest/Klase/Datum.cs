using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaTest.Klase
{
    public class Datum
    {
        public string time { get; set; }
        public string time_local { get; set; }
        public double? temperature { get; set; }
        public double? dewpoint { get; set; }
        public int? humidity { get; set; }
        public object precipitation { get; set; }
        public object precipitation_3 { get; set; }
        public double? precipitation_6 { get; set; }
        public object snowdepth { get; set; }
        public double? windspeed { get; set; }
        public object peakgust { get; set; }
        public int? winddirection { get; set; }
        public double? pressure { get; set; }
        public object condition { get; set; }

    }
}