using Microsoft.AspNetCore.Mvc;
using Mangaedb.Model;
using Mangaedb.Services;

namespace Mangaedb.Controllers
{
    public class CategoriaController : Controller , IDisposable
    {
        MangaedbContext _db = new MangaedbContext();

        public ActionResult Index()
        {
            List<Categoria> oCat = CategoriaService.GetCategorias();

            return View(oCat);
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            Categoria? oCat = _db.Categoria.Find(id);
            return View(oCat);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Categoria oCat = new Categoria();
                oCat.Nome = collection["Nome"];

                _db.Categoria.Add(oCat);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            Categoria? oCat = _db.Categoria.Find(id);

            if (oCat == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(oCat);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Categoria? oCat = _db.Categoria.Find(id);

                if (oCat == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                oCat.Nome = collection["Nome"];

                _db.Categoria.Update(oCat);

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            Categoria? oCat = _db.Categoria.Find(id);
            return View(oCat);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Categoria? oCat = _db.Categoria.Find(id);

                if (oCat == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _db.Categoria.Remove(oCat);

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
