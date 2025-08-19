namespace ConsumingWebService.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using System.Xml.Serialization;

    #region JSON-only DTO
    public class WeatherJsonResponseDTO
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherItem> Weather { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public MainInfo Main { get; set; }

        [JsonPropertyName("visibility")]
        public int? Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("dt")]
        public long? Dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int? Timezone { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int? Cod { get; set; }
    }
    #endregion

    #region XML-only DTO
    [XmlRoot("current")]
    public class WeatherXmlResponseDTO
    {
        [XmlElement("city")]
        public CityXml City { get; set; }

        [XmlElement("temperature")]
        public TemperatureXml Temperature { get; set; }

        [XmlElement("feels_like")]
        public ValueUnitXml FeelsLike { get; set; }

        [XmlElement("humidity")]
        public ValueUnitXml Humidity { get; set; }

        [XmlElement("pressure")]
        public ValueUnitXml Pressure { get; set; }

        [XmlElement("wind")]
        public WindXml Wind { get; set; }

        [XmlElement("clouds")]
        public CloudsXml Clouds { get; set; }

        [XmlElement("visibility")]
        public ValueXml Visibility { get; set; }

        [XmlElement("precipitation")]
        public PrecipitationXml Precipitation { get; set; }

        [XmlElement("weather")]
        public WeatherXml Weather { get; set; }

        [XmlElement("lastupdate")]
        public LastUpdateXml LastUpdate { get; set; }
    }
    #endregion

    #region JSON Classes
    public class Coord
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }

    public class WeatherItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    public class MainInfo
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double? FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double? TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double? TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int? Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int? Humidity { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double? Speed { get; set; }

        [JsonPropertyName("deg")]
        public int? Deg { get; set; }

        [JsonPropertyName("gust")]
        public double? Gust { get; set; }
    }

    public class Rain
    {
        [JsonPropertyName("1h")]
        public double? OneHour { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int? All { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("sunrise")]
        public long? Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long? Sunset { get; set; }
    }
    #endregion

    #region XML-specific classes
    public class CityXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("coord")]
        public CoordXml Coord { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("timezone")]
        public int Timezone { get; set; }

        [XmlElement("sun")]
        public Sun Sun { get; set; }
    }

    public class CoordXml
    {
        [XmlAttribute("lon")]
        public double Lon { get; set; }

        [XmlAttribute("lat")]
        public double Lat { get; set; }
    }

    public class Sun
    {
        [XmlAttribute("rise")]
        public DateTime Rise { get; set; }

        [XmlAttribute("set")]
        public DateTime Set { get; set; }
    }

    public class TemperatureXml
    {
        [XmlAttribute("value")]
        public double Value { get; set; }

        [XmlAttribute("min")]
        public double Min { get; set; }

        [XmlAttribute("max")]
        public double Max { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }

    public class ValueUnitXml
    {
        [XmlAttribute("value")]
        public double Value { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }

    public class ValueXml
    {
        [XmlAttribute("value")]
        public double Value { get; set; }
    }

    public class WindXml
    {
        [XmlElement("speed")]
        public SpeedElement Speed { get; set; }

        [XmlElement("gusts")]
        public GustsElement Gusts { get; set; }

        [XmlElement("direction")]
        public DirectionElement Direction { get; set; }
    }

    public class SpeedElement
    {
        [XmlAttribute("value")]
        public double Value { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class GustsElement
    {
        [XmlAttribute("value")]
        public double Value { get; set; }

        public bool ShouldSerializeValue()
        {
            return Value > 0;
        }
    }

    public class DirectionElement
    {
        [XmlAttribute("value")]
        public double Value { get; set; }

        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class CloudsXml
    {
        [XmlAttribute("value")]
        public int Value { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class PrecipitationXml
    {
        [XmlAttribute("mode")]
        public string Mode { get; set; }

        [XmlAttribute("value")]
        public string ValueString { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }

        [XmlIgnore]
        public double? Value
        {
            get
            {
                if (double.TryParse(ValueString, out double result))
                    return result;
                return null;
            }
        }
    }

    public class WeatherXml
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("icon")]
        public string Icon { get; set; }
    }

    public class LastUpdateXml
    {
        [XmlAttribute("value")]
        public DateTime Value { get; set; }
    }
    #endregion
}