using KartaTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace KartaTest.Klase
{
    public static class XmlPrognozaGraf
    {
       public static string vratiXml(List<ModelPrognoza> prognoza)
        {
            Weatherdata klasaXml = new Weatherdata();
            klasaXml.Credit = new Credit();
            klasaXml.Credit.Link = new Link();
            klasaXml.Credit.Link.Text = "Prognoza sa yr.no, Norveška stranica za prognozu";
            klasaXml.Credit.Link.Url = "http://www.yr.no/place/Croatia/" + prognoza[0].grad + "/";
            klasaXml.Location = new Location();
            klasaXml.Location.Country = "Hrvatska";
            klasaXml.Location.Type = "City";
            klasaXml.Location.Name = prognoza[0].grad;
            klasaXml.Forecast = new Forecast();
            klasaXml.Forecast.Tabular = new Tabular();
            klasaXml.Forecast.Tabular.Time = new List<Time>();
            string datumJedan;
            string datumDva;
            string datum;
            foreach (ModelPrognoza red in prognoza)
            {
                Time redakTimeJedan = new Time();
                Time redakTimeDva = new Time();
                datumJedan = DateTime.Parse(red.datum).AddHours(-1).ToString("yyyy-MM-ddTHH:00:00");
                datum = DateTime.Parse(red.datum).ToString("yyyy-MM-ddTHH:00:00");
                datumDva = DateTime.Parse(red.datum).AddHours(1).ToString("yyyy-MM-ddTHH:00:00");
                redakTimeJedan.From = datumJedan;
                redakTimeJedan.To = datum;
                redakTimeDva.From = datum;
                redakTimeDva.To = datumDva;
                redakTimeJedan.Precipitation = redakTimeDva.Precipitation = new Precipitation();
                redakTimeJedan.Precipitation.Value = redakTimeDva.Precipitation.Value = red.padalineKisa.ToString().Replace(',', '.');
                redakTimeJedan.Pressure = redakTimeDva.Pressure = new Pressure();
                redakTimeJedan.Pressure.Value = redakTimeDva.Pressure.Value = "0";
                redakTimeJedan.Symbol = redakTimeDva.Symbol = new Symbol();
                redakTimeJedan.Symbol.Name = redakTimeDva.Symbol.Name = red.vrijeme;
                redakTimeJedan.Symbol.Var = redakTimeDva.Symbol.Var = red.ikona;
                redakTimeJedan.Temperature = redakTimeDva.Temperature = new Temperature();
                redakTimeJedan.Temperature.Value = redakTimeDva.Temperature.Value = red.temperatura.ToString().Replace(',', '.');
                redakTimeJedan.WindDirection = redakTimeDva.WindDirection = new WindDirection();
                redakTimeJedan.WindDirection.Deg = redakTimeDva.WindDirection.Deg = (red.brojSmjerVjetra+180).ToString().Replace(',', '.');
                redakTimeJedan.WindSpeed = redakTimeDva.WindSpeed = new WindSpeed();
                redakTimeJedan.WindSpeed.Mps = redakTimeDva.WindSpeed.Mps = red.brzinaVjetra.ToString().Replace(',','.');

                klasaXml.Forecast.Tabular.Time.Add(redakTimeJedan);
                klasaXml.Forecast.Tabular.Time.Add(redakTimeDva);

            }
            using (StringWriter stringWriter = new StringWriter() )
            {
                var serializator = new XmlSerializer(klasaXml.GetType());
                serializator.Serialize(stringWriter, klasaXml);
                return "`"+ stringWriter.ToString()+ "`";
            }
            
        } 
    }
}