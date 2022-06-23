using Mangaedb.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mangaedb.Services
{
    public class MangaService
    {
        public static List<Manga> GetMangas()
        {
            MangaedbContext _db = new MangaedbContext();

            List<Manga> lCat = _db.Manga.ToList();

            return lCat;
        }

        public static IEnumerable<KeyValuePair<Manga, int>> GetTopMangas(DateTime dateTime, int qtd = 15)
        {
            MangaedbContext _db = new MangaedbContext();

            List<Manga> mangas = MangaService.GetMangas();

            Dictionary<Manga, int> mgs = new Dictionary<Manga, int>();

            foreach (Manga manga in mangas)
            {
                int curtidaManga = _db.CurtidaManga
                    .Where(cm => cm.IdManga == manga.Id)
                    .Where(cm => cm.CreatedAt >= dateTime)
                    .Count();
                mgs.Add(manga, curtidaManga);
            }

            var topMangas = from entry in mgs orderby entry.Value descending, entry.Key.Nome ascending select entry;

            return topMangas.Take(qtd);
        }
    }
}
