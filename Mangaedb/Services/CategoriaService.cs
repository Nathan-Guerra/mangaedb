using Mangaedb.Model;

namespace Mangaedb.Services
{
    public class CategoriaService
    {
        public static List<Categoria> GetCategorias()
        {
            MangaedbContext _db = new MangaedbContext();

            List<Categoria> lCat = _db.Categoria.ToList();

            return lCat;
        }
    }
}
