using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KartaTest.Models
{
    public class ModelPrognoza
    {
        [Display(Name ="Sat")]
        public string datum { get; set; }

        [Display(Name = "Grad")]
        public string grad { get; set; }
        [Display(Name ="Ikona")]
        public string ikona { get; set; }
        [Display(Name ="Vrijeme")]
        public string vrijeme { get; set; }
        [Display(Name ="Temperatura")]
        public double temperatura { get; set; }
        [Display(Name ="Količina kiše")]
        public double padalineKisa { get; set; }
        [Display(Name ="Količina snijega")]
        public double padalineSnijeg { get; set; }
        [Display(Name ="Vlažnost")]
        public double vlaznost { get; set; }
        [Display(Name ="Smjer vjetra")]
        public string smjerVjetra { get; set; }
        [Display(Name ="Brzina vjetra")]
        public double brzinaVjetra { get; set; }
        public double brojSmjerVjetra { get; set; }
    }
}