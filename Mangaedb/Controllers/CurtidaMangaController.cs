using Microsoft.AspNetCore.Mvc;
using Mangaedb.Model;
using Mangaedb.Services;

namespace Mangaedb.Controllers
{
    public class CurtidaMangaController : Controller, IDisposable
    {
        MangaedbContext _db = new MangaedbContext();

        public ActionResult Index()
        {
            List<CurtidaManga> curtidas = _db.CurtidaManga.ToList();

            return View(curtidas);
        }

        // GET: CurtidaMangaController/Details/5
        public ActionResult Details(int id)
        {
            CurtidaManga? oCur = _db.CurtidaManga.Find(id);
            return View(oCur);
        }

        // GET: CurtidaMangaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurtidaMangaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                CurtidaManga oCur = new CurtidaManga();
                oCur.IdUsuario = int.Parse(collection["IdUsuario"]);
                oCur.IdManga = int.Parse(collection["IdManga"]);
                oCur.CreatedAt= DateTime.Now;

                _db.CurtidaManga.Add(oCur);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CurtidaMangaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CurtidaManga? oCur = _db.CurtidaManga.Find(id);

                if (oCur == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _db.CurtidaManga.Remove(oCur);

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
