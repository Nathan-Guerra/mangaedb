using Microsoft.AspNetCore.Mvc;
using Mangaedb.Model;
using Mangaedb.Services;

namespace Mangaedb.Controllers
{
    public class ComentarioController : Controller , IDisposable
    {
        MangaedbContext _db = new MangaedbContext();

        // POST: ComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch
            {
                return Redirect("/");
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
                    return Redirect(Request.Headers["Referer"].ToString());
                }

                _db.Comentario.Remove(oCom);

                _db.SaveChanges();

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch
            {
                return Redirect("/");
            }
        }
    }
}
