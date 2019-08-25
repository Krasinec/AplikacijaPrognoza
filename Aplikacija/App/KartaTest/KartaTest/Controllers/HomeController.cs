using KartaTest.Klase;
using KartaTest.Klase.ipLokacijaDohvat;
using KartaTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KartaTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Pocetna()
        {
            string xml = "";
            string ipApi = "61a019727e2f936ec99d58f4596de2b4";
            string ipKorisnika = HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            ipKorisnika = HttpContext.Request.UserHostAddress;
            if (!string.IsNullOrEmpty(ipKorisnika))
            {
                HttpWebRequest apiRequest =
                WebRequest.Create("http://api.ipstack.com/"+ipKorisnika+"?access_key="+
                ipApi+"&format=1") as HttpWebRequest;

                string apiOdgovor = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader citac = new StreamReader(response.GetResponseStream());
                    apiOdgovor = citac.ReadToEnd();
                }
                IpApiPomocneKlase odgovor = JsonConvert.DeserializeObject<IpApiPomocneKlase>(apiOdgovor);
                if (!string.IsNullOrEmpty(odgovor.city))
                {
                    List<ModelPrognoza> prognoza = new List<ModelPrognoza>();
                    PrognozaPrikaz dohvat = new PrognozaPrikaz();
                    prognoza = dohvat.DohvatZaPrikaz(odgovor.city, "Peterodnevna");
                    if (prognoza.Count() > 0)
                    {
                       xml = XmlPrognozaGraf.vratiXml(prognoza);
                    }
                }
            }
            ViewData["xml"] = xml;
            return View();
        }


        public ActionResult Karta()
        {
            ViewBag.Message = "Karta.";

            return View();
        }
    }
}