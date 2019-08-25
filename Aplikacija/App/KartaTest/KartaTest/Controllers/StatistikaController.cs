using KartaTest.Klase;
using KartaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KartaTest.Controllers
{
    public class StatistikaController : Controller
    {
        SelectList gradovi;
        SelectList podatakStat;
        SelectList statistikaZa;
        SelectList statistika;
        SelectList godine;
        // GET: Statistika
        public ActionResult Prikaz()
        {
            gradovi = new SelectList(new List<SelectListItem> {
                new SelectListItem {Selected = true, Text="Zagreb", Value="Zagreb"},
                new SelectListItem {Selected = false, Text="Zadar", Value="Zadar"},
                new SelectListItem {Selected = false, Text="Split", Value="Split"},
                new SelectListItem {Selected = false, Text="Rijeka", Value="Rijeka"},
                new SelectListItem {Selected = false, Text="Pula", Value="Pula"},
                new SelectListItem {Selected = false, Text="Osijek", Value="Osijek"},
                new SelectListItem {Selected = false, Text="Krapina", Value="Krapina"},
                new SelectListItem {Selected = false, Text="Dubrovnik", Value="Dubrovnik"}
            }, "Value", "Text", 1);
            podatakStat = new SelectList(new List<SelectListItem> {
                new SelectListItem {Selected = true, Text="Temperatura", Value="temperatura"},
                new SelectListItem {Selected = false, Text="Pritisak", Value="pritisak"},
                new SelectListItem {Selected = false, Text="Vlažnost", Value="vlaznost"},
                new SelectListItem {Selected = false, Text="Padaline", Value="padaline"},
                new SelectListItem {Selected = false, Text="Brzina vjetra", Value="brzinaVjetra"},
                new SelectListItem {Selected = false, Text="Smjer vjetra", Value="smjerVjetra"}
            }, "Value", "Text", 1);
            statistikaZa = new SelectList(new List<SelectListItem> {
                new SelectListItem {Selected = true, Text="Godina", Value="Godina"},
                new SelectListItem {Selected = false, Text="Mjesec", Value="Mjesec"},
                new SelectListItem {Selected = false, Text="Godina po mjesecima", Value="GodPoMjesec"}
            }, "Value", "Text", 1);
            statistika = new SelectList(new List<SelectListItem> {
                new SelectListItem {Selected = true, Text="Maksimum", Value="max"},
                new SelectListItem {Selected = false, Text="Minimum", Value="min"},
                new SelectListItem {Selected = false, Text="Prosjek", Value="avg"}
            }, "Value", "Text", 1);
            int godina = int.Parse(DateTime.Now.Year.ToString());
            List<SelectListItem> listaGodine = new List<SelectListItem>();
            for (int i = 2000; i < godina; i++)
            {
                SelectListItem jednaGodina = new SelectListItem();
                jednaGodina.Selected = false;
                jednaGodina.Value = i.ToString();
                jednaGodina.Text = i.ToString();
                listaGodine.Add(jednaGodina);
            }
            listaGodine[0].Selected = true;
            godine = new SelectList(listaGodine, "Value", "Text", 1);
            ModelZaPrikazStat model= new ModelZaPrikazStat();
            model.forma = new ModelStatistikaForma();
            model.godine = godine;
            model.podatakStat = podatakStat;
            model.statistika = statistika;
            model.statistikaZa = statistikaZa;
            model.gradovi = gradovi;
            model.rezultat = null;
            return View(model);
        }
        [HttpPost]
        public ActionResult Prikaz(ModelZaPrikazStat model)
        {
            ModelStatistika zaPrikaz = new ModelStatistika();
            PrikazStat prikazStat = new PrikazStat();
            if(model.forma.statistikaZa == "Godina")
            {
                zaPrikaz = prikazStat.PrikazGodina(model.forma.godina.ToString(), model.forma.podatakStat, model.forma.statistika, model.forma.grad);
            }
            else if (model.forma.statistikaZa == "Mjesec")
            {
                string mjesec;
                mjesec = model.forma.mjesec.ToString();
                zaPrikaz=prikazStat.PrikazMjesec(model.forma.godina.ToString(),model.forma.podatakStat,model.forma.statistika,model.forma.grad,mjesec);
            }
            else
            {
                zaPrikaz = prikazStat.PrikazGodPoMjesec(model.forma.godina.ToString(), model.forma.podatakStat, model.forma.statistika, model.forma.grad);
            }
            gradovi = new SelectList(new List<SelectListItem> {
                new SelectListItem {Selected = true, Text="Zagreb", Value="Zagreb"},
                new SelectListItem {Selected = false, Text="Zadar", Value="Zadar"},
                new SelectListItem {Selected = false, Text="Split", Value="Split"},
                new SelectListItem {Selected = false, Text="Rijeka", Value="Rijeka"},
                new SelectListItem {Selected = false, Text="Pula", Value="Pula"},
                new SelectListItem {Selected = false, Text="Osijek", Value="Osijek"},
                new SelectListItem {Selected = false, Text="Krapina", Value="Krapina"},
                new SelectListItem {Selected = false, Text="Dubrovnik", Value="Dubrovnik"}
            }, "Value", "Text", 1);
            podatakStat = new SelectList(new List<SelectListItem> {
                new SelectListItem {Selected = true, Text="Temperatura", Value="temperatura"},
                new SelectListItem {Selected = false, Text="Pritisak", Value="pritisak"},
                new SelectListItem {Selected = false, Text="Vlažnost", Value="vlaznost"},
                new SelectListItem {Selected = false, Text="Padaline", Value="padaline"},
                new SelectListItem {Selected = false, Text="Brzina vjetra", Value="brzinaVjetra"},
                new SelectListItem {Selected = false, Text="Smjer vjetra", Value="smjerVjetra"}
            }, "Value", "Text", 1);
            statistikaZa = new SelectList(new List<SelectListItem> {
                new SelectListItem {Selected = true, Text="Godina", Value="Godina"},
                new SelectListItem {Selected = false, Text="Mjesec", Value="Mjesec"},
                new SelectListItem {Selected = false, Text="Godina po mjesecima", Value="GodPoMjesec"}
            }, "Value", "Text", 1);
            statistika = new SelectList(new List<SelectListItem> {
                new SelectListItem {Selected = true, Text="Maksimum", Value="max"},
                new SelectListItem {Selected = false, Text="Minimum", Value="min"},
                new SelectListItem {Selected = false, Text="Prosjek", Value="avg"}
            }, "Value", "Text", 1);
            int godina = int.Parse(DateTime.Now.Year.ToString());
            List<SelectListItem> listaGodine = new List<SelectListItem>();
            for (int i = 2000; i < godina; i++)
            {
                SelectListItem jednaGodina = new SelectListItem();
                jednaGodina.Selected = false;
                jednaGodina.Value = i.ToString();
                jednaGodina.Text = i.ToString();
                listaGodine.Add(jednaGodina);
            }
            listaGodine[0].Selected = true;
            godine = new SelectList(listaGodine, "Value", "Text", 1);
            ModelZaPrikazStat modelPrikaz = new ModelZaPrikazStat();
            modelPrikaz.forma = new ModelStatistikaForma();
            modelPrikaz.godine = godine;
            modelPrikaz.podatakStat = podatakStat;
            modelPrikaz.statistika = statistika;
            modelPrikaz.statistikaZa = statistikaZa;
            modelPrikaz.gradovi = gradovi;
            modelPrikaz.rezultat = zaPrikaz;
            StatPodaciRij klasaRijecnik = new StatPodaciRij();
            modelPrikaz.rijecnik = klasaRijecnik.DohvatRijecnik();
            return View(modelPrikaz);
        }
    }
}