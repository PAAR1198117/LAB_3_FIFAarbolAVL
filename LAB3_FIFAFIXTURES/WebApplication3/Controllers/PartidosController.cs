using Newtonsoft.Json;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Partidos/Details/5
        public ActionResult Details(int id)
        {
            var model = Data.Instance.Partidos.FirstOrDefault(x => x.NoPartido == id);
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
                    NoPartido = Convert.ToInt16(collection["Numero de Partido"]),
                    Fecha = Convert.ToDateTime(collection["Fecha de Partido"]),
                    Grupo = collection["Grupo de Partido"],
                    Pais1 = collection["Local"],
                    Pais2 = collection["Visitante"],
                    Estadio = collection["Estadio"]
                };
                return RedirectToAction("Index");
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
                    NoPartido = Convert.ToInt16(collection["Numero de Partido"]),
                    Fecha = Convert.ToDateTime(collection["Fecha de Partido"]),
                    Grupo = collection["Grupo de Partido"],
                    Pais1 = collection["Local"],
                    Pais2 = collection["Visitante"],
                    Estadio = collection["Estadio"]
                };
                Data.Instance.Partidos.Remove(Data.Instance.Partidos.First(x => x.NoPartido == id)); //Elimino el jugador que coincida el ID
                Data.Instance.Partidos.Add(model); // Agrego el "nuevo" jugador (Realmente el jugador modificado)
                return RedirectToAction("Index");
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
            try
            {
                // TODO: Add delete logic here
                Data.Instance.Partidos.Remove(Data.Instance.Partidos.First(x => x.NoPartido == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Importar()
        {
            return View(Data.Instance.Partidos);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<Partido> partidosFIFA = new List<Partido>();
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


                Partido partido_oficial = JsonConvert.DeserializeObject<Partido>(JSON_DATA);

                partidosFIFA.Add(new Partido
                {
                    NoPartido = partido_oficial.NoPartido,
                    Fecha = partido_oficial.Fecha,
                    Grupo = partido_oficial.Grupo,
                    Pais1 = partido_oficial.Pais1,
                    Pais2 = partido_oficial.Pais2,
                    Estadio = partido_oficial.Estadio
                });
                //agregar la funcion de aregar pais mandando el JSON_DATA
            }
            return RedirectToAction("Index");
        }



    }
}
