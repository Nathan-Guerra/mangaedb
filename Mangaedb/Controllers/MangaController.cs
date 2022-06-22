using Mangaedb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;
namespace Mangaedb.Controllers
{
    public class MangaController : Controller, IDisposable
    {
        MangaedbContext _db = new MangaedbContext();

        public ActionResult Index()
        {
            List<Manga> mangas = _db.Manga.ToList();

            return View(mangas);
        }

        // GET: MangaController/Details/5
        public ActionResult Details(int id)
        {
            dynamic models = new ExpandoObject();
            models.Manga = _db.Manga.Find(id);

            if (models.Manga == null)
            {
                return RedirectToAction("Index");
            }

            models.Comentarios = _db.Comentario.Where(c => c.IdManga == id).ToList();
            models.CurtidasManga = _db.CurtidaManga.Where(cm => cm.IdManga == id).Count();
            models.Categorias = new List<Categoria>();

            List<CategoriaManga> cm = _db.CategoriaManga.Where(cm => cm.IdManga == id).ToList();

            if (cm.Count > 0)
            {
                foreach (CategoriaManga catMan in cm)
                {
                    Categoria? oCat = _db.Categoria.Find(catMan.IdCategoria);

                    if (oCat != null)
                    {
                        models.Categorias.Add(oCat);
                    }
                }
            }

            return View(models);
        }

        // GET: MangaController/Create
        public ActionResult Create()
        {
            List<Categoria> oCat = _db.Categoria.ToList();

            ViewBag.Categorias = oCat;

            return View();
        }

        // POST: MangaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Manga oMan = new Manga();
                oMan.Nome = collection["Nome"];
                oMan.Sinopse = collection["Sinopse"];

                String[] categorias = collection["Categorias"];


                categorias.GetType();

                _db.Manga.Add(oMan);

                _db.SaveChanges();

                foreach (string idCategoria in categorias)
                {
                    CategoriaManga oCm = new CategoriaManga();
                    oCm.IdManga = oMan.Id;
                    oCm.IdCategoria = int.Parse(idCategoria);

                    _db.CategoriaManga.Add(oCm);
                }

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Manga? oMan = _db.Manga.Find(id);

            if (oMan == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(oMan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Manga? oMan = _db.Manga.Find(id);

                if (oMan == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                oMan.Nome = collection["Nome"];
                oMan.Sinopse = collection["Sinopse"];

                _db.Manga.Update(oMan);

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Manga? oMan = _db.Manga.Find(id);
            return View(oMan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Manga? oMan = _db.Manga.Find(id);

                if (oMan == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _db.Manga.Remove(oMan);

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
