using KartaTest.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaTest.Models
{
    public class ModelZaPrikaz
    {
        public ModelPrognozaForma forma { get; set; }
        public IEnumerable<ModelPrognoza> prognoza { get; set; }
        public string xml { get; set; }
        public DaniUTjednuRij rijecnik { get; set; }

    }
}