using AgilFoods.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AgilFoods.Context
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DBContext")
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cardapio> Cardapio { get; set; }
        public DbSet<GeraCardapio> GeraCardapio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Para que os campos Fornecedor e FornecedorId da tabela Produto tenham os mesmos valores
            modelBuilder.Entity<Produto>().HasRequired(p => p.Fornecedor).WithMany().HasForeignKey(p => p.FornecedorId);
            modelBuilder.Entity<Produto>().Property(t => t.FornecedorId).HasColumnName("Fornecedor_Id");
            //Para que os campos Fornecedor e FornecedorId da tabela Cardapio tenham os mesmos valores
            modelBuilder.Entity<Cardapio>().HasRequired(p => p.Fornecedor).WithMany().HasForeignKey(p => p.FornecedorId);
            modelBuilder.Entity<Cardapio>().Property(t => t.FornecedorId).HasColumnName("Fornecedor_Id");
            //Para que os campos Fornecedor e FornecedorId da tabela GeraCardapio tenham os mesmos valores
            modelBuilder.Entity<GeraCardapio>().HasRequired(p => p.Fornecedor).WithMany().HasForeignKey(p => p.FornecedorId);
            modelBuilder.Entity<GeraCardapio>().Property(t => t.FornecedorId).HasColumnName("Fornecedor_Id");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}