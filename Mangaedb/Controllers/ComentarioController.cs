using Microsoft.AspNetCore.Mvc;
using Mangaedb.Model;
using Mangaedb.Services;

namespace Mangaedb.Controllers
{
    public class ComentarioController : Controller , IDisposable
    {
        MangaedbContext _db = new MangaedbContext();

        public ActionResult Index()
        {
            List<Comentario> comentarios = _db.Comentario.ToList();

            return View(comentarios);
        }

        // GET: ComentarioController/Details/5
        public ActionResult Details(int id)
        {
            Comentario? oCom = _db.Comentario.Find(id);
            return View(oCom);
        }

        // GET: ComentarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Comentario oCom = new Comentario();
                oCom.IdManga = int.Parse(collection["IdManga"]);
                oCom.IdUsuario = int.Parse(collection["IdUsuario"]);
                oCom.Conteudo= collection["Conteudo"];
                oCom.CreatedAt = DateTime.Now;

                _db.Comentario.Add(oCom);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ComentarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Comentario? oCom = _db.Comentario.Find(id);

                if (oCom == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _db.Comentario.Remove(oCom);

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
