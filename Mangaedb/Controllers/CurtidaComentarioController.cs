using Microsoft.AspNetCore.Mvc;
using Mangaedb.Model;
using Mangaedb.Services;

namespace Mangaedb.Controllers
{
    public class CurtidaComentarioController : Controller, IDisposable
    {
        MangaedbContext _db = new MangaedbContext();

        public ActionResult Index()
        {
            List<CurtidaComentario> curtidas = _db.CurtidaComentario.ToList();

            return View(curtidas);
        }

        // GET: CurtidaComentarioController/Details/5
        public ActionResult Details(int id)
        {
            CurtidaComentario? oCur = _db.CurtidaComentario.Find(id);
            return View(oCur);
        }

        // GET: CurtidaComentarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurtidaComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                CurtidaComentario oCur = new CurtidaComentario();
                oCur.IdUsuario = int.Parse(collection["IdUsuario"]);
                oCur.IdComentario = int.Parse(collection["IdComentario"]);
                oCur.ValorCurtida = byte.Parse(collection["ValorCurtida"]);

                _db.CurtidaComentario.Add(oCur);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CurtidaComentarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CurtidaComentario? oCur = _db.CurtidaComentario.Find(id);

                if (oCur == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _db.CurtidaComentario.Remove(oCur);

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
