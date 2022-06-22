using Microsoft.EntityFrameworkCore;
using ProdutoStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStoreApi.DataBase
{
    public class ProdStoreContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PRODUTOSTORE;Trusted_Connection=True;");
        }
    }
}
