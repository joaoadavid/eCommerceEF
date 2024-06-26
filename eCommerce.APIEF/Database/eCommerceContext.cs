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
        public eCommerceContext(DbContextOptions<eCommerceContext> options) :base (options)
        {
            
        }

    }
}
