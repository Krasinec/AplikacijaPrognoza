using KartaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaTest.Klase
{
    public class PrikazStat
    {
        DohvatStat dohvat = new DohvatStat();
        public ModelStatistika PrikazGodina(string godina, string podatak, string statistika, string grad)
        {
            List<double> listaRezultata = new List<double>();
            ModelStatistika prikaz = new ModelStatistika();
            prikaz.datumi = new List<string>();
            prikaz.rezultati = new List<double>();
            prikaz.grad = grad;
            prikaz.podatak = podatak;
            prikaz.statistikaZa = "Godina";
            prikaz.datumi.Add(godina);
            for (int i = 1; i <= 12; i++)
            {
                listaRezultata.Add(dohvat.DohvatStatistike(godina, podatak, statistika, grad, i.ToString()));
                
            }
            if(statistika == "max")
            {
                prikaz.rezultati.Add(Math.Round(listaRezultata.Max(),2));
                prikaz.statistika = "Maksimum";
            }
            else if (statistika == "min")
            {
                prikaz.rezultati.Add(Math.Round(listaRezultata.Min(),2));
                prikaz.statistika = "Minimum";
            }
            else
            {
                prikaz.rezultati.Add(Math.Round(listaRezultata.Average(),2));
                prikaz.statistika = "Prosjek";
            }
            return prikaz;
        }
        public ModelStatistika PrikazMjesec(string godina, string podatak, string statistika, string grad, string mjesec)
        {
            double rezultat = dohvat.DohvatStatistike(godina,podatak,statistika,grad,mjesec);
            ModelStatistika prikaz = new ModelStatistika();
            prikaz.datumi = new List<string>();
            prikaz.rezultati = new List<double>();
            prikaz.grad = grad;
            prikaz.podatak = podatak;
            prikaz.rezultati.Add(rezultat);
            prikaz.statistikaZa = "Mjesec";
            if (int.Parse(mjesec) < 10)
            {
                prikaz.datumi.Add(godina + "-0" + mjesec);
            }
            else
            {
                prikaz.datumi.Add(godina + "-" + mjesec);
            }
            if (statistika == "max")
            {
                prikaz.statistika = "Maksimum";
            }
            else if (statistika == "min")
            {
                prikaz.statistika = "Minimum";
            }
            else
            {
                prikaz.statistika = "Prosjek";
            }
            return prikaz;
        }
        public ModelStatistika PrikazGodPoMjesec(string godina, string podatak, string statistika, string grad)
        {
            ModelStatistika prikaz = new ModelStatistika();
            prikaz.datumi = new List<string>();
            prikaz.rezultati = new List<double>();
            prikaz.grad = grad;
            prikaz.podatak = podatak;
            prikaz.statistikaZa = "Godina po mjesecima";
            for (int i = 1; i <= 12; i++)
            {
                prikaz.rezultati.Add(dohvat.DohvatStatistike(godina, podatak, statistika, grad, i.ToString()));
                if (i < 10)
                {
                    prikaz.datumi.Add(godina + "-0" + i.ToString());
                }
                else
                {
                    prikaz.datumi.Add(godina + "-" + i.ToString());
                }

            }
            if (statistika == "max")
            {
                prikaz.statistika = "Maksimum";
            }
            else if (statistika == "min")
            {
                prikaz.statistika = "Minimum";
            }
            else
            {
                prikaz.statistika = "Prosjek";
            }
            return prikaz;
        }

    }
}