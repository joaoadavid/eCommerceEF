using Microsoft.EntityFrameworkCore;

namespace eCommerce.APIEF.Database
{
    public class eCommerceContext : DbContext
    {
        #region Conexão sem distinção de ambientes de execução
        /*
         * 
         

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //indica o tipo de banco de dados utilizado
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerceEF;Integrated Security=True;");
        }
        */
        #endregion
                                                   //base é um construtor do DbContextOptions
        public eCommerceContext(DbContextOptions<eCommerceContext> options) :base (options)
        {
            Usuario usuario = new Usuario();

            
        }
        //cria a instancia dos bancos para que o EF possa gerar através das migrations
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        public DbSet<EnderecoEntrega> EnderecoEntregas { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1 ,Nome = "Moda"},
                new Departamento { Id = 1, Nome = "Informática"},
                new Departamento { Id = 1, Nome = "Eletro"},
                new Departamento { Id = 1, Nome = "Vestuario"}
                );
        }
    }
}
