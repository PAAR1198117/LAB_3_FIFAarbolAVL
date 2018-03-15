using lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3.Clases
{
    public class Data
    {
        private static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }

        public List<Country> Partidos;

        public Data()
        {
            Partidos = new List<Country>();
        }
    }
}