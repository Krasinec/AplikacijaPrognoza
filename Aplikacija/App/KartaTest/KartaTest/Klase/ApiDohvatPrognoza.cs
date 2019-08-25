using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace KartaTest.Klase
{
    public class ApiDohvatPrognoza
    {
        public void ApiPriprema()
        {
            ApiDohvat();
            RecurringJob.AddOrUpdate("Prvi",() => ApiDohvat(),("30 1 * * *"),TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("Drugi", () => ApiDohvat(), ("30 4 * * *"), TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("Treci", () => ApiDohvat(), ("30 7 * * *"), TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("Cetverti", () => ApiDohvat(), ("30 10 * * *"), TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("Peti", () => ApiDohvat(), ("30 13 * * *"), TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("Sesti", () => ApiDohvat(), ("30 16 * * *"), TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("Sedmi", () => ApiDohvat(), ("30 19 * * *"), TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("Osmi", () => ApiDohvat(), ("30 22 * * *"), TimeZoneInfo.Local);
        }
        public void ApiDohvat()
        {
            List<Gradovi> gradovi = new List<Gradovi>();
            using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
            {
                gradovi = kontekst.Gradovi.ToList();
            }
            int brojGradova = gradovi.Count();
            for (int i = 0; i < brojGradova ; i++)
            {
                Gradovi trenutniGrad = new Gradovi();
                trenutniGrad = gradovi[i];
                string grad = trenutniGrad.imeGrad;
                string apiKljuc = "29162b051f109cc1be64040092ba2918";
                HttpWebRequest apiRequest =
                WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast?q=" +
                grad + ",hr&appid=" + apiKljuc + "&units=metric&lang=hr") as HttpWebRequest;

                string apiOdgovor = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    //HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse;
                    StreamReader citac = new StreamReader(response.GetResponseStream());
                    apiOdgovor = citac.ReadToEnd();
                }

                KorjenskiObjekt listaOdgovor = JsonConvert.DeserializeObject<KorjenskiObjekt>(apiOdgovor);
                List<Prognoza> listaPrognoza = new List<Prognoza>();
                foreach (var clan in listaOdgovor.list)
                {
                    Prognoza zaDodati = new Prognoza();
                    zaDodati.datum = DateTime.Parse(clan.dt_txt);
                    zaDodati.grad = trenutniGrad.id;
                    zaDodati.temperatura = clan.main.temp;
                    zaDodati.vlaznost = clan.main.humidity;
                    zaDodati.vrijeme = clan.weather[0].description;
                    zaDodati.ikona = clan.weather[0].icon;
                    if (clan.rain != null)
                    {
                        zaDodati.kisa = clan.rain.kolicinaKise;
                    }
                    else
                    {
                        zaDodati.kisa = 0;
                    }
                    if (clan.snow != null)
                    {
                        zaDodati.snijeg = clan.snow.kolicinaSnijega;
                    }
                    else
                    {
                        zaDodati.snijeg = 0;
                    }
                    if (clan.wind != null)
                    {
                        zaDodati.smjerVjetra = clan.wind.deg;
                        zaDodati.brzinaVjetra = clan.wind.speed;
                    }
                    listaPrognoza.Add(zaDodati);
                }
                ProvjeraISpremanje(listaPrognoza);
                if (i % 56 == 0 && i!=0) {
                    Thread.Sleep(60000);
                }
            }
            return;
            }

        public void ProvjeraISpremanje(List<Prognoza> listaPrognoza)
        {
            DateTime datum = DateTime.Now.AddHours(-2);
            List<Prognoza> progUBazi = new List<Prognoza>();
            int grad = listaPrognoza.First().grad;
            using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
            {
               progUBazi = kontekst.Prognoza.Where(c => c.datum >= datum && c.grad == grad).ToList();
            }
            if (progUBazi.Count == 0)
            {
                using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
                {
                    kontekst.Prognoza.AddRange(listaPrognoza);
                    kontekst.SaveChanges();
                }
            }
            else if (progUBazi.Count == listaPrognoza.Count - 1)
            {
                Prognoza zadnjiUListi = listaPrognoza.Last();
                listaPrognoza.RemoveAt(listaPrognoza.Count - 1);
                string bazaLista = string.Join(";", progUBazi);
                string dohvatLista = string.Join(";", listaPrognoza);
                
                if (!(bazaLista == dohvatLista))
                {
                    using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
                    {
                        foreach (Prognoza red in listaPrognoza)
                        {
                            kontekst.Prognoza.Add(red);
                            kontekst.Entry(red).State = System.Data.Entity.EntityState.Modified;
                        }
                        kontekst.SaveChanges();
                    }
                }
                using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
                {
                    kontekst.Prognoza.Add(zadnjiUListi);
                    kontekst.SaveChanges();
                }
            }else if (progUBazi.Count == listaPrognoza.Count)
            {
                string bazaLista = string.Join(";", progUBazi);
                string dohvatLista = string.Join(";", listaPrognoza);

                if (!(bazaLista == dohvatLista))
                {
                    using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
                    {
                        foreach (Prognoza red in listaPrognoza)
                        {
                            kontekst.Prognoza.Add(red);
                            kontekst.Entry(red).State = System.Data.Entity.EntityState.Modified;
                        }
                        kontekst.SaveChanges();
                    }
                }

            }
            else
            {
                using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
                {
                    foreach (Prognoza red in listaPrognoza)
                    {   if(kontekst.Prognoza.Any(e => e.datum == red.datum && e.grad == red.grad))
                        {
                            kontekst.Prognoza.Add(red);
                            kontekst.Entry(red).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            kontekst.Prognoza.Add(red);
                        }
                    }
                    kontekst.SaveChanges();
                }
            }
        }
    }
}