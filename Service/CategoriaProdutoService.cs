using Microsoft.EntityFrameworkCore;
using ProdutoStoreApi.DataBase;
using ProdutoStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStoreApi.Service
{
    public class CategoriaProdutoService
    {
        private readonly ProdStoreContext dbContext = new();
        public CategoriaProduto Set(CategoriaProduto catProduto)
        {
            try
            {
                dbContext.CategoriaProdutos.Add(catProduto);
                dbContext.SaveChanges();
            } catch
            {
                throw;
            }
            return catProduto;

        }

        public IQueryable<CategoriaProduto> Get()
        {
            try
            {
                return dbContext.CategoriaProdutos.Include(p=>p.Produtos).AsNoTracking(); 
            }
            catch
            {
                throw;
            }
        }
    }
}
