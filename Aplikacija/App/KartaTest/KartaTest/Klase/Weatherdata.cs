using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace KartaTest.Klase
{
    [XmlRoot(ElementName = "location")]
    public class Location
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
    }

    [XmlRoot(ElementName = "link")]
    public class Link
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "credit")]
    public class Credit
    {
        [XmlElement(ElementName = "link")]
        public Link Link { get; set; }
    }

    [XmlRoot(ElementName = "symbol")]
    public class Symbol
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "var")]
        public string Var { get; set; }
    }

    [XmlRoot(ElementName = "precipitation")]
    public class Precipitation
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "windDirection")]
    public class WindDirection
    {
        [XmlAttribute(AttributeName = "deg")]
        public string Deg { get; set; }
    }

    [XmlRoot(ElementName = "windSpeed")]
    public class WindSpeed
    {
        [XmlAttribute(AttributeName = "mps")]
        public string Mps { get; set; }
    }

    [XmlRoot(ElementName = "temperature")]
    public class Temperature
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; } = "celsius";
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "pressure")]
    public class Pressure
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; } = "hPa";
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "time")]
    public class Time
    {
        [XmlElement(ElementName = "symbol")]
        public Symbol Symbol { get; set; }
        [XmlElement(ElementName = "precipitation")]
        public Precipitation Precipitation { get; set; }
        [XmlElement(ElementName = "windDirection")]
        public WindDirection WindDirection { get; set; }
        [XmlElement(ElementName = "windSpeed")]
        public WindSpeed WindSpeed { get; set; }
        [XmlElement(ElementName = "temperature")]
        public Temperature Temperature { get; set; }
        [XmlElement(ElementName = "pressure")]
        public Pressure Pressure { get; set; }
        [XmlAttribute(AttributeName = "from")]
        public string From { get; set; }
        [XmlAttribute(AttributeName = "to")]
        public string To { get; set; }
    }

    [XmlRoot(ElementName = "tabular")]
    public class Tabular
    {
        [XmlElement(ElementName = "time")]
        public List<Time> Time { get; set; }
    }

    [XmlRoot(ElementName = "forecast")]
    public class Forecast
    {
        [XmlElement(ElementName = "tabular")]
        public Tabular Tabular { get; set; }
    }

    [XmlRoot(ElementName = "weatherdata")]
    public class Weatherdata
    {
        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }
        [XmlElement(ElementName = "credit")]
        public Credit Credit { get; set; }
        [XmlElement(ElementName = "forecast")]
        public Forecast Forecast { get; set; }
    }

}