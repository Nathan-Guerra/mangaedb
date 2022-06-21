using Microsoft.AspNetCore.Mvc;
using Mangaedb.Model;
using Mangaedb.Services;
using System.Security.Cryptography;
using System.Text;

namespace Mangaedb.Controllers
{
    public class UsuarioController : Controller , IDisposable
    {
        MangaedbContext _db = new MangaedbContext();

        public ActionResult Index()
        {
            List<Usuario> mangas = _db.Usuario.ToList();

            return View(mangas);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            Usuario? oUsr = _db.Usuario.Find(id);
            return View(oUsr);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Usuario oUsr = new Usuario();
                oUsr.Nome = collection["Nome"];
                oUsr.Email = collection["Email"];
                oUsr.Senha = collection["Senha"];
                oUsr.Ativo = true;

                _db.Usuario.Add(oUsr);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario? oUsr = _db.Usuario.Find(id);

            if (oUsr == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(oUsr);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Usuario? oUsr = _db.Usuario.Find(id);

                if (oUsr == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                oUsr.Email = collection["Email"];

                _db.Usuario.Update(oUsr);

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario? oUsr = _db.Usuario.Find(id);
            return View(oUsr);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                Usuario? oUsr = _db.Usuario.Find(id);

                if (oUsr == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                oUsr.Ativo = false;

                _db.Usuario.Update(oUsr);

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private String encryptPassword(string password)
        {
            byte[] encode = Encoding.UTF8.GetBytes(password);
            
            return Convert.ToBase64String(encode);
        }
    }
}
