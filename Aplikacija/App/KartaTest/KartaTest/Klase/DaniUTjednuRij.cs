using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaTest.Klase
{
    public class DaniUTjednuRij
    {
        public Dictionary<int,string> daniUTjednu { get; set; }
        public DaniUTjednuRij()
        {
            daniUTjednu = new Dictionary<int, string>();
            daniUTjednu.Add(1, "Pon");
            daniUTjednu.Add(2, "Uto");
            daniUTjednu.Add(3, "Sri");
            daniUTjednu.Add(4, "Čet");
            daniUTjednu.Add(5, "Pet");
            daniUTjednu.Add(6, "Sub");
            daniUTjednu.Add(0, "Ned");
        }
    }
}