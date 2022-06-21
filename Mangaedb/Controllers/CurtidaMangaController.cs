using Microsoft.AspNetCore.Mvc;
using Mangaedb.Model;


namespace Mangaedb.Controllers
{
    public class CurtidaMangaController : Controller, IDisposable
    {
        MangaedbContext _db = new MangaedbContext();

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
