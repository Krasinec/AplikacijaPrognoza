using KartaTest.Klase;
using KartaTest.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KartaTest.Controllers
{
    public class PrognozaController : Controller
    {
        public ActionResult Prikaz()
        {
            ModelZaPrikaz modelPrikaz = new ModelZaPrikaz();
            modelPrikaz.forma = new ModelPrognozaForma();
            modelPrikaz.prognoza = null;
            modelPrikaz.rijecnik = new DaniUTjednuRij();
            return View(modelPrikaz);
        }
        [HttpPost]
        public ActionResult Prikaz(ModelZaPrikaz model)
        {
            PrognozaPrikaz zaPrikaz = new PrognozaPrikaz();
            List<ModelPrognoza> rezultat = new List<ModelPrognoza>();
            rezultat = zaPrikaz.DohvatZaPrikaz(model.forma.trazeniGrad,model.forma.VrstaPrognoze);
            ModelZaPrikaz modelPrikaz = new ModelZaPrikaz();
            modelPrikaz.forma = new ModelPrognozaForma();
            modelPrikaz.prognoza = rezultat;
            if (rezultat.Count > 0)
            {
                modelPrikaz.xml = XmlPrognozaGraf.vratiXml(rezultat);
            }
            modelPrikaz.rijecnik = new DaniUTjednuRij();
            return View(modelPrikaz);
        }
    }
}