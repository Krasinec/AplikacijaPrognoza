using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KartaTest.Models
{
    public class ModelStatistika
    {
        public string grad { get; set; }
        public string statistikaZa { get; set; }
        public string podatak { get; set; }
        public string statistika { get; set; }
        public List<double> rezultati { get; set; }
        [Display(Name ="Datum")]
        public List<string> datumi { get; set; }

    }
}