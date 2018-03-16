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
        //}
        //public class Nodo1
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo2
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo3
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo4
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo5
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo6
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo7
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo8
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo9
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo10
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo11
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Nodo12
        //{
        //    public int noPartido { get; set; }
        //    public string FechaPartido { get; set; }
        //    public string Grupo { get; set; }
        //    public string Pais1 { get; set; }
        //    public string Pais2 { get; set; }
        //    public string Estadio { get; set; }
        //}

        //public class Partido
        //{
        //    public Nodo1 nodo1 { get; set; }
        //    public Nodo2 nodo2 { get; set; }
        //    public Nodo3 nodo3 { get; set; }
        //    public Nodo4 nodo4 { get; set; }
        //    public Nodo5 nodo5 { get; set; }
        //    public Nodo6 nodo6 { get; set; }
        //    public Nodo7 nodo7 { get; set; }
        //    public Nodo8 nodo8 { get; set; }
        //    public Nodo9 nodo9 { get; set; }
        //    public Nodo10 nodo10 { get; set; }
        //    public Nodo11 nodo11 { get; set; }
        //    public Nodo12 nodo12 { get; set; }
        //}
    }
}