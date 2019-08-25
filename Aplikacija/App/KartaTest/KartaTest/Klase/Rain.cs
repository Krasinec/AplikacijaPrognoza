using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaTest.Klase
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double kolicinaKise { get; set; }
    }
}