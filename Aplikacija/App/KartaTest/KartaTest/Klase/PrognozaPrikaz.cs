using KartaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaTest.Klase
{
    public class PrognozaPrikaz
    {
        public List<ModelPrognoza> DohvatZaPrikaz(string grad, string vrstaPrognoze)
        {
            List<ModelPrognoza> odgovor = new List<ModelPrognoza>();
            Gradovi trazeniGrad = new Gradovi();
            using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
            {
                trazeniGrad = kontekst.Gradovi.Where(c => c.imeGrad == grad).FirstOrDefault();
            }
            if (trazeniGrad != null) {
                List<Prognoza> prognoza = new List<Prognoza>();
                if (vrstaPrognoze == "Jednodnevna")
                {
                    DateTime datumPocetak = DateTime.Now.AddHours(-2);
                    DateTime datumKraj = DateTime.Now.AddHours(22);
                    using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
                    {
                        prognoza = kontekst.Prognoza.Where(c => c.datum >= datumPocetak && c.datum <= datumKraj && c.grad == trazeniGrad.id).ToList();
                    }

                }
                else if (vrstaPrognoze == "Peterodnevna")
                {
                    DateTime datumPocetak = DateTime.Now.AddHours(-2);
                    using (BazaVremProgEntities kontekst = new BazaVremProgEntities())
                    {
                        prognoza = kontekst.Prognoza.Where(c => c.datum >= datumPocetak && c.grad == trazeniGrad.id).ToList();
                    }
                }
                if (prognoza.Count > 0)
                {
                    foreach (Prognoza zapis in prognoza)
                    {
                        ModelPrognoza zapisModel = new ModelPrognoza();
                        zapisModel.vrijeme = zapis.vrijeme;
                        zapisModel.temperatura = zapis.temperatura;
                        zapisModel.grad = grad;
                        zapisModel.datum = zapis.datum.ToString();
                        zapisModel.vlaznost = zapis.vlaznost;
                        zapisModel.padalineKisa = zapis.kisa;
                        zapisModel.padalineSnijeg = zapis.snijeg;
                        zapisModel.ikona = zapis.ikona;
                        zapisModel.brojSmjerVjetra = zapis.smjerVjetra;
                        zapisModel.brzinaVjetra = zapis.brzinaVjetra;
                        if(zapisModel.brzinaVjetra != 0)
                        {
                            if (zapis.smjerVjetra <= 30 || zapis.smjerVjetra >= 330)
                            {
                                zapisModel.smjerVjetra = "S";
                            }
                            else if (zapis.smjerVjetra > 30 && zapis.smjerVjetra < 60)
                            {
                                zapisModel.smjerVjetra = "SI";
                            }
                            else if (zapis.smjerVjetra >= 60 && zapis.smjerVjetra <= 120)
                            {
                                zapisModel.smjerVjetra = "I";
                            }
                            else if (zapis.smjerVjetra > 120 && zapis.smjerVjetra < 150)
                            {
                                zapisModel.smjerVjetra = "JI";
                            }
                            else if (zapis.smjerVjetra >= 150 && zapis.smjerVjetra <= 210)
                            {
                                zapisModel.smjerVjetra = "J";
                            }
                            else if (zapis.smjerVjetra > 210 && zapis.smjerVjetra < 240)
                            {
                                zapisModel.smjerVjetra = "JZ";
                            }
                            else if (zapis.smjerVjetra >= 240 && zapis.smjerVjetra <= 300)
                            {
                                zapisModel.smjerVjetra = "Z";
                            }
                            else
                            {
                                zapisModel.smjerVjetra = "SZ";
                            }
                        }
                        odgovor.Add(zapisModel);

                    }
                }
            }
            
            return odgovor;
        }
    }
}