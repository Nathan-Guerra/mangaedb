using Mangaedb.Model;
using Microsoft.Extensions.Primitives;

namespace Mangaedb.Services
{
    public class CategoriaMangaService
    {
        public static List<CategoriaManga> GetCategoriaManga(int id)
        {
            MangaedbContext _db = new MangaedbContext();

            List<CategoriaManga> lCm = _db.CategoriaManga.Where(cm => cm.IdManga == id).ToList();

            return lCm;
        }

        public static void SetCategoriaManga(int id, StringValues categorias)
        {
            MangaedbContext _db = new MangaedbContext();

            WipeCategoriaManga(id, _db);

            foreach (string idCategoria in categorias)
            {
                CategoriaManga oCm = new()
                {
                    IdManga = id,
                    IdCategoria = int.Parse(idCategoria)
                };

                _db.CategoriaManga.Add(oCm);
            }

            _db.SaveChanges();
        }

        private static void WipeCategoriaManga(int idManga, MangaedbContext _db)
        {
            var cm = _db.CategoriaManga.Where(cm => cm.IdManga == idManga);

            _db.CategoriaManga.RemoveRange(cm);
            _db.SaveChanges();
        }
    }
}
