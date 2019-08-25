using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace KartaTest.Klase
{
    public class DohvatStat
    {
        Dictionary<string, string> rijecnikGradovi = new Dictionary<string, string>();
        public DohvatStat()
        {
            rijecnikGradovi.Add("Zagreb", "14236");
            rijecnikGradovi.Add("Dubrovnik", "14474");
            rijecnikGradovi.Add("Split", "14445");
            rijecnikGradovi.Add("Zadar", "14431");
            rijecnikGradovi.Add("Rijeka", "13116");
            rijecnikGradovi.Add("Pula", "14307");
            rijecnikGradovi.Add("Krapina", "14234");
            rijecnikGradovi.Add("Osijek", "14280");
        }
        public double DohvatStatistike(string godina, string podatak, string statistika, string grad, string mjesec)
        {
            double rezultat=0;
            int brojDana = DateTime.DaysInMonth(int.Parse(godina), int.Parse(mjesec));
            string pocetakDatum = godina + "-" + mjesec + "-01";
            string krajDatum = godina + "-" + mjesec + "-" + brojDana.ToString();
            DateTime pocetakTD =DateTime.Parse(pocetakDatum + " 00:00:00");
            DateTime krajTD = DateTime.Parse(krajDatum + " 23:00:00");
            int idGrad;
            bool postoji;
            using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
            {
                idGrad = kontekst.Gradovi.Where(l => l.imeGrad == grad).Select(l => l.id).FirstOrDefault();
                postoji=kontekst.Statistika.Any(e => e.datum >= pocetakTD && e.datum <= krajTD && e.grad == idGrad);
            }
            if (!postoji)
            {
                ApiDohvatStatistike(idGrad, grad, pocetakDatum, krajDatum);
            }
            using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
            {
                if(statistika == "max")
                {
                    if(podatak == "temperatura")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.temperatura).DefaultIfEmpty(0).Max();
                    }else if (podatak == "pritisak")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.pritisak).DefaultIfEmpty(0).Max();
                    }
                    else if (podatak == "vlaznost")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.vlaznost).DefaultIfEmpty(0).Max();
                    }
                    else if (podatak == "padaline")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.kisa).DefaultIfEmpty(0).Max();
                    }
                    else if (podatak == "brzinaVjetra")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.brzinaVjetra).DefaultIfEmpty(0).Max();
                    }
                    else if (podatak == "smjerVjetra")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.smjerVjetra).DefaultIfEmpty(0).Max();
                    }
                }
                else if (statistika == "min")
                {
                    if (podatak == "temperatura")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.temperatura).DefaultIfEmpty(0).Min();
                    }
                    else if (podatak == "pritisak")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.pritisak).DefaultIfEmpty(0).Min();
                    }
                    else if (podatak == "vlaznost")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.vlaznost).DefaultIfEmpty(0).Min();
                    }
                    else if (podatak == "padaline")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.kisa).DefaultIfEmpty(0).Min();
                    }
                    else if (podatak == "brzinaVjetra")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.brzinaVjetra).DefaultIfEmpty(0).Min();
                    }
                    else if (podatak == "smjerVjetra")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.smjerVjetra).DefaultIfEmpty(0).Min();
                    }
                }
                else {
                    if (podatak == "temperatura")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.temperatura).DefaultIfEmpty(0).Average();
                    }
                    else if (podatak == "pritisak")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.pritisak).DefaultIfEmpty(0).Average();
                    }
                    else if (podatak == "vlaznost")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.vlaznost).DefaultIfEmpty(0).Average();
                    }
                    else if (podatak == "padaline")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.kisa).DefaultIfEmpty(0).Average();
                    }
                    else if (podatak == "brzinaVjetra")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.brzinaVjetra).DefaultIfEmpty(0).Average();
                    }
                    else if (podatak == "smjerVjetra")
                    {
                        rezultat = kontekst.Statistika.Where(p => p.datum >= pocetakTD && p.datum <= krajTD && p.grad == idGrad).Select(p => p.smjerVjetra).DefaultIfEmpty(0).Average();
                    }
                }
            }
            return Math.Round(rezultat,2);
        }
        public void ApiDohvatStatistike(int idGrad, string grad,string pocetak,string kraj)
        {
            string apiKljuc = "8e50al2m";
            HttpWebRequest apiRequest =
                WebRequest.Create("https://api.meteostat.net/v1/history/hourly?" +
                "station=" +rijecnikGradovi[grad] +"&start=" + pocetak+"&end=" + kraj+"&time_zone=Europe/Zagreb&time_format=Y-m-d%20H:i&key="
                +apiKljuc) as HttpWebRequest;

            string apiOdgovor = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader citac = new StreamReader(response.GetResponseStream());
                apiOdgovor = citac.ReadToEnd();
            }

            KorijenskiStatistika listaOdgovor = JsonConvert.DeserializeObject<KorijenskiStatistika>(apiOdgovor);
            List<Statistika> listaStatistika = new List<Statistika>();
            Statistika prijasniRed = new Statistika();
            prijasniRed.datum = new DateTime(1990,1,1,7,0,0);
            foreach (var clan in listaOdgovor.data)
            {
                Statistika redStatistika = new Statistika();
                redStatistika.datum = DateTime.Parse(clan.time_local);
                redStatistika.grad = idGrad;
                if (clan.windspeed != null)
                {
                    redStatistika.brzinaVjetra = double.Parse(clan.windspeed.ToString());
                }
                else
                {
                    redStatistika.brzinaVjetra = 0;
                }
                if (clan.precipitation != null)
                {
                    redStatistika.kisa = double.Parse(clan.precipitation.ToString());
                }
                else
                {
                    redStatistika.kisa = 0;
                }
                if(clan.pressure != null)
                {
                    redStatistika.pritisak = double.Parse(clan.pressure.ToString());
                }
                else
                {
                    redStatistika.pritisak = 0;
                }
                
                if (clan.winddirection != null)
                {
                    redStatistika.smjerVjetra = double.Parse(clan.winddirection.ToString());
                }
                else
                {
                    redStatistika.smjerVjetra = 0;
                }

                if (clan.snowdepth != null)
                {
                    redStatistika.snijeg = double.Parse(clan.snowdepth.ToString());
                }
                else
                {
                    redStatistika.snijeg = 0;
                }
                if (clan.temperature != null)
                {
                    redStatistika.temperatura = double.Parse(clan.temperature.ToString());
                }
                else
                {
                    redStatistika.temperatura = 0;
                }
                if (clan.humidity != null)
                {
                    redStatistika.vlaznost = double.Parse(clan.humidity.ToString());
                }
                else
                {
                    redStatistika.vlaznost = 0;
                }
                if(prijasniRed.datum != redStatistika.datum)
                {
                    listaStatistika.Add(redStatistika);
                }
                prijasniRed = redStatistika;
            }
            if (listaStatistika.Count() > 0) {
                using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
                {
                    kontekst.Statistika.AddRange(listaStatistika);
                    kontekst.SaveChanges();
                }
            }
            



        }
    }
}