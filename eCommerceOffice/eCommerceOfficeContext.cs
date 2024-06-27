using eCommerceOffice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceOffice
{
    public class eCommerceOfficeContext : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }

        public DbSet<ColaboradorSetor> ColaboradorSetores { get; set; }

        public DbSet<Setor> Setores { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("//query de login ao cadastro");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mapping: ColaboradorSetor
            modelBuilder.Entity<ColaboradorSetor>().HasKey(a => new { a.ColaboradorId, a.SetorId });
            modelBuilder.Entity<ColaboradorSetor>()
                .HasOne(a => a.Colaborador)
                .WithMany(a => a.ColaboradorSetores)
                .HasForeignKey(a => a.ColaboradorId);

            modelBuilder.Entity<ColaboradorSetor>()
                .HasOne(a => a.Setor)
                .WithMany(a => a.ColaboradoresSetores).
                HasForeignKey(a => a.SetorId);
            #endregion
            #region mapping efcore 5
            modelBuilder.Entity<Colaborador>().HasMany(a => a.Turmas).WithMany(a => a.Colaboradores);

            #endregion

            #region colaborador <-> veiculo
            modelBuilder.Entity<Colaborador>()
                .HasMany(a => a.Veiculos)
                .WithMany(a => a.Colaboradores)
                .UsingEntity<ColaboradorVeiculo>(
                    q => q.HasOne(a => a.Veiculo).WithMany(a => a.ColaboradoresVeiculos).HasForeignKey(a => a.VeiculoId),
                    q => q.HasOne(a => a.Colaborador).WithMany(a => a.ColaboradoresVeiculos).HasForeignKey(a => a.ColaboradorId)
                    q => q.HasKey(a=>new {a.ColaboradorId, a.VeiculoId})
                    );
            
            #endregion
            #region seeds
            modelBuilder.Entity<Colaborador>().HasData(
                new Colaborador() { Id = 1, Nome = "Felipe" },
                new Colaborador() { Id = 2, Nome = "José" },
                new Colaborador() { Id = 3, Nome = "Mariano" },
                new Colaborador() { Id = 4, Nome = "Jessica" },
                new Colaborador() { Id = 5, Nome = "Vivian" }
                );
            modelBuilder.Entity<Setor>().HasData(
            new Setor() { Id = 1, Nome = "Logistica" },
            new Setor() { Id = 2, Nome = "Separação" },
            new Setor() { Id = 3, Nome = "Administrativo" }
            );

            modelBuilder.Entity<ColaboradorSetor>().HasData(
                new ColaboradorSetor() { SetorId = 1, ColaboradorId = 1 },
                new ColaboradorSetor() { SetorId = 2, ColaboradorId = 6 },
                new ColaboradorSetor() { SetorId = 3, ColaboradorId = 5 },
                new ColaboradorSetor() { SetorId = 4, ColaboradorId = 4 }
                );

            modelBuilder.Entity<ColaboradorSetor>().HasData(
                new ColaboradorSetor() { SetorId = 1,ColaboradorId = 1, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 1,ColaboradorId = 1, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 1,ColaboradorId = 1, Criado = DateTimeOffset.Now },
                new ColaboradorSetor() { SetorId = 1,ColaboradorId = 1, Criado = DateTimeOffset.Now });

            modelBuilder.Entity<Turma>().HasData(
                new Turma() { Id = 1 , Nome = "turma a1"},
                new Turma() { Id = 2 , Nome = "turma a2"},
                new Turma() { Id = 3 , Nome = "turma a3"},
                new Turma() { Id = 4 , Nome = "turma a4"}
                
                
                
                
                );



            // modelBuilder.Entity<Colaborador>().HasMany(a => a.ColaboradorSetoress).WithOne(a => a.Colaborador).HasForeignKey(a => a.ColaboradorId);
            // modelBuilder.Entity<Setor>().HasMany(a => a.ColaboradoresSetores).WithOne(a => a.Setor).HasForeignKey(a => a.SetorId);
            #endregion
        }
    }
}