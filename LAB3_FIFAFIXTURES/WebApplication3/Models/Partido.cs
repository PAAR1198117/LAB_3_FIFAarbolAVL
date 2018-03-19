using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public partial class Partido
    {
        [JsonProperty("noPartido")]
        public int NoPartido { get; set; }

        [JsonProperty("FechaPartido")]
        public string FechaPartido { get; set; }

        [JsonProperty("Grupo")]
        public string Grupo { get; set; }

        [JsonProperty("Pais1")]
        public string Pais1 { get; set; }

        [JsonProperty("Pais2")]
        public string Pais2 { get; set; }

        [JsonProperty("Estadio")]
        public string Estadio { get; set; }
    }

    public partial class Partido
    {
        public static Dictionary<string, Partido> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, Partido>>(json, WebApplication3.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Dictionary<string, Partido> self) => JsonConvert.SerializeObject(self, WebApplication3.Models.Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}