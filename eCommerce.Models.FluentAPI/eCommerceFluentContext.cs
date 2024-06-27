using eCommerce.Models.FluentAPI.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.FluentAPI
{

    public class eCommerceFluentContext : DbContext
    {

        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {

        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecoEntregas { get; set; }

        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region explicações 
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>().Property(a => a.RG).HasColumnName("REGISTRO_GERAL").HasMaxLength(10);
            modelBuilder.Entity<Usuario>().Ignore(a => a.Sexo);
            modelBuilder.Entity<Usuario>().Property(a => a.Id).ValueGeneratedOnAdd();//Identity auto increment

            modelBuilder.Entity<Usuario>().HasIndex("CPF").IsUnique().HasFilter("[CPF] is not null").HasDatabaseName("IX_CPF");
            modelBuilder.Entity<Usuario>().HasIndex(a => a.CPF);

            modelBuilder.Entity<Usuario>().HasIndex("CPF", "EMAIL");
            modelBuilder.Entity<Usuario>().HasIndex(a => new { a.CPF, a.Email });

            modelBuilder.Entity<Usuario>().HasKey("Id");
            modelBuilder.Entity<Usuario>().HasKey(a => a.Id);

            modelBuilder.Entity<Usuario>().HasKey("Id", "CPF");
            modelBuilder.Entity<Usuario>().HasKey(a => new { a.Id, a.CPF });

            modelBuilder.Entity<Usuario>().HasNoKey();
            modelBuilder.Entity<Usuario>().HasAlternateKey("CPF");

            modelBuilder.Entity<Usuario>().HasOne(usu => usu.Contato).WithOne(cont => cont.Usuario).HasForeignKey<Contato>(a => a.UsuarioId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Usuario>().HasMany(usu => usu.EnderecosEntrega).WithOne(a => a.Usuario).HasForeignKey(end => end.UsuarioId); ;
            modelBuilder.Entity<Usuario>().HasMany(usu => usu.Departamentos).WithMany(dep => dep.Usuarios);

            modelBuilder.Entity<Usuario>().Property(a => a.RG).IsRequired().HasMaxLength(12);

            modelBuilder.Entity<Usuario>().Property(a => a.preco).HasPrecision(2);
            #endregion

            #region Usuario
            modelBuilder.Entity<Usuario>().HasKey(a => a.Id);

            #endregion

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

        }
    }
}

