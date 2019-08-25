using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaTest.Klase
{
    public class StatPodaciRij
    {
        public Dictionary<string,string> DohvatRijecnik()
        {
            Dictionary<string, string> rijecnik = new Dictionary<string, string>();
            rijecnik.Add("temperatura", "Temperatura, °C");
            rijecnik.Add("pritisak", "Pritisak, hPa");
            rijecnik.Add("vlaznost", "Vlažnost, %");
            rijecnik.Add("padaline", "Padaline, mm");
            rijecnik.Add("brzinaVjetra", "Brzina vjetra, km/h");
            rijecnik.Add("smjerVjetra", "Smjer vjetra, °");
            return rijecnik;
        }
    }
}