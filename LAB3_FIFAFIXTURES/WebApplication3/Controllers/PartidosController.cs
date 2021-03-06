﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Clases;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    
    public class PartidosController : Controller
    {                    
        public BinaryTree<partidos> btree = new BinaryTree<partidos>();
        public registros historial = new registros();
        private string cadena = "";
              
        public class partidos : IComparable
        {
            public int noMatch { get; set; }
            public DateTime datematch { get; set; }
            public string group { get; set; }
            public string country1{ get; set; }
            public string country2 { get; set; }
            public string stadium { get; set; }
            public partidos(int noMatch, DateTime datematch, string group, string country1, string country2, string stadium)
            {
                this.noMatch = noMatch;
                this.datematch = datematch;
                this.group = group;
                this.country1 = country1;
                this.country2 = country2;
                this.stadium = stadium;
            }
            public int CompareTo(object obj) {
                partidos compareToObj = (partidos)obj;
                return this.noMatch.CompareTo(compareToObj.noMatch);
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Partidos/Details/5
        public ActionResult Details(int id)
        {
            var model = Data.Instance.Partidos.FirstOrDefault(x => x.NoPartido == id);
            cadena += " se mostraron detalles de un nodo, \n";
            historial.escribirArchivo(cadena);                       
            return View(model);
        }

        // GET: Partidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partidos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var model = new Partido
                {
                    NoPartido = Convert.ToInt16(collection["noPartido"]),
                    FechaPartido = (collection["FechaPartido"]),
                    Grupo = collection["Grupo"],
                    Pais1 = collection["Pais1"],
                    Pais2 = collection["Pais2"],
                    Estadio = collection["Estadio"]
                };
                Data.Instance.Partidos.Add(model);
                partidos toAdd = new partidos(model.NoPartido, Convert.ToDateTime(model.FechaPartido), model.Grupo, model.Pais1, model.Pais2, model.Estadio);
                btree.AddNode(toAdd);
                btree.AVL();
                cadena += "se creo un nuevo nodo, \n";               
                cadena += "se agrego al arbol un nuevo nodo, \n";
                cadena += "se balanceo el arbol, \n";
                historial.escribirArchivo(cadena);                               
                return RedirectToAction("Importar");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partidos/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Data.Instance.Partidos.FirstOrDefault(x => x.NoPartido == id);
            return View(model);
        }

        // POST: Partidos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var model = new Partido
                {
                    NoPartido = Convert.ToInt16(collection["noPartido"]),
                    FechaPartido = (collection["FechaPartido"]),
                    Grupo = collection["Grupo"],
                    Pais1 = collection["Pais1"],
                    Pais2 = collection["Pais2"],
                    Estadio = collection["Estadio"]
                };
                partidos toModifi = new partidos(model.NoPartido,Convert.ToDateTime(model.FechaPartido), model.Grupo,model.Pais1,model.Pais2,model.Estadio);
                /*
                 * aque agregar logica de editas
                 * 
                 * porque no me sale
                */
                
                btree.Find(btree.Root,toModifi);
                Data.Instance.Partidos.Remove(Data.Instance.Partidos.First(x => x.NoPartido == id)); //Elimino el jugador que coincida el ID
                Data.Instance.Partidos.Add(model); // Agrego el "nuevo" jugador (Realmente el jugador modificado)
                cadena += "Se edito un nodo, \n";
                historial.escribirArchivo(cadena);
                return RedirectToAction("Importar");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partidos/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Data.Instance.Partidos.FirstOrDefault(x => x.NoPartido == id);
            return View();
        }

        // POST: Partidos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // TODO: Add delete logic here
            //partidos dataToDelete = new partidos(noMatch, (DateTime) datematch,  group,  country1,  country2,  stadium);
            //Data.Instance.Partidos.Remove(Data.Instance.Partidos.First(x => x.NoPartido == noMatch));

            Data.Instance.Partidos.Remove(Data.Instance.Partidos.First(x => x.NoPartido == id)); //Elimino el jugador que coincida el ID
            var model = new Partido
            {
                NoPartido = Convert.ToInt16(collection["noPartido"]),
                FechaPartido = (collection["FechaPartido"]),
                Grupo = collection["Grupo"],
                Pais1 = collection["Pais1"],
                Pais2 = collection["Pais2"],
                Estadio = collection["Estadio"]
            };
            partidos toDelete = new partidos(model.NoPartido, Convert.ToDateTime(model.FechaPartido), model.Grupo, model.Pais1, model.Pais2, model.Estadio);
            btree.DeleteNode(toDelete);
            btree.AVL();
            cadena += "se elimino un nodo, \n";
            cadena += "se balanceo el arbol, \n";           
            historial.escribirArchivo(cadena);
            return RedirectToAction("Importar");            
        }

        public ActionResult Importar()
        {
            return View(Data.Instance.Partidos);
        }

        [HttpPost]
        public ActionResult Importar(HttpPostedFileBase postedFile)
        {
            partidos datatoadd;
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                
                string JSON_DATA = System.IO.File.ReadAllText(filePath);
                var partido = Partido.FromJson(JSON_DATA);
                
                foreach (var item in partido)
                {
                    Data.Instance.Partidos.Add(new Partido
                    {
                        NoPartido = item.Value.NoPartido,
                        FechaPartido = item.Value.FechaPartido,
                        Grupo = item.Value.Grupo,
                        Pais1 = item.Value.Pais1,
                        Pais2 = item.Value.Pais2,
                        Estadio = item.Value.Estadio                        
                    });
                    datatoadd = new partidos(item.Value.NoPartido, Convert.ToDateTime(item.Value.FechaPartido), item.Value.Grupo, item.Value.Pais1, item.Value.Pais2, item.Value.Estadio);
                    btree.AddNode(datatoadd);
                    btree.AVL();
                    cadena += "se cargo un nodo al arbol, \n";
                    historial.escribirArchivo(cadena);
                }                
            }
            return RedirectToAction("Importar");
        }
            
    }    
}
