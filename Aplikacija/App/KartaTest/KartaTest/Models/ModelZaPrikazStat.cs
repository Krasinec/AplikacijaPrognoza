using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KartaTest.Models
{
    public class ModelZaPrikazStat
    {
        public ModelStatistikaForma forma { get; set; }
        public SelectList gradovi { get; set; }
        public SelectList podatakStat { get; set; }
        public SelectList statistika { get; set; }
        public SelectList godine { get; set; }
        public SelectList statistikaZa { get; set; }
        public ModelStatistika rezultat { get; set; }
        public Dictionary<string,string> rijecnik { get; set; }
    }
}