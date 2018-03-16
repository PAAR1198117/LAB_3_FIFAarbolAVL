using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Clases
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

        public List<Partidos> Partidos;

        public Data()
        {
            Partidos = new List<Partidos>();
        }
    }
}