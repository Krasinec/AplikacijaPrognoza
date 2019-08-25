using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaTest.Klase
{
    public class Snow
    {
        [JsonProperty("3h")]
        public double kolicinaSnijega { get; set; }
    }
}