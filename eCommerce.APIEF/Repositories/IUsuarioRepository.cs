using eCommerce.Models;

namespace eCommerce.APIEF.Repositories
{
    public interface IUsuarioRepository 
    {
        /*
         * CRUD
         */

        List<Usuario> Get();
        Usuario Get(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}
