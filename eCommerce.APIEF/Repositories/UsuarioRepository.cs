using eCommerce.APIEF.Database;
using eCommerce.Models;

namespace eCommerce.APIEF.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //cria uma variavel do banco context apenas para leitura
        private readonly eCommerceContext _db;
        
        // cria uma instancia de usuario repository com o parametro do banco e da o valor para ele
        //injetando o valor da propriedade ao _db
        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }
       
        public List<Usuario> Get()
        {
            // neste caso converte _db que é uma variavel DbSet em uma lista.

            return _db.Usuarios.OrderBy(a => a.Id).ToList();
            
        }
        public Usuario Get(int id)
        {
            return _db.Usuarios.Find(id)!;
        }
        public void Add(Usuario usuario)
        {
            // Unit of Works
            // o Entity framework guarda todas as operações em memória e para que sejam enviadas ao banco
            // é necessário que ele utilize o método SaveChanges() para que as operações sejam enviadas para o banco
            _db.Usuarios.Add(usuario);//passa o tipo do dbset

            _db.SaveChanges();
        }
        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Usuarios.Remove(Get(id));
            _db.SaveChanges();
        }
    }
}
