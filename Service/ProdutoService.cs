using Microsoft.EntityFrameworkCore;
using ProdutoStoreApi.DataBase;
using ProdutoStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStoreApi.Service
{
    public class ProdutoService
    {
        ProdStoreContext dbContext = new ProdStoreContext();
        public IQueryable<Produto> Get()
        {
            return dbContext.Produtos.Include(p=>p.CategoriaProduto).ToList().AsQueryable();
        }

        public Produto Set(Produto produto)
        {
            try
            {
                produto.Ativo = true;
                dbContext.Produtos.Add(produto);
                dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return produto;

        }

        public Produto Update(Produto produto)
        {
            try
            {
                dbContext.Update(produto);
                dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return produto;


        }

        public Produto Delete(Produto produto)
        {
            try
            {
                dbContext.Remove(produto);
                dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return produto;
        }

        public bool ProdutoValidation(Produto produto)
        {

            if ((string.IsNullOrEmpty(produto.Nome)) || (string.IsNullOrEmpty(produto.Descricao)) || (produto.CategoriaID ==0))
                return false;

            return true;
        }
    }
}
