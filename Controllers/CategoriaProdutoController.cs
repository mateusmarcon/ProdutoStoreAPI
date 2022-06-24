using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProdutoStoreApi.DataBase;
using ProdutoStoreApi.Models;
using ProdutoStoreApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly CategoriaProdutoService catProdService = new();

        [HttpGet]
        [EnableQuery]
        public IQueryable<CategoriaProduto> Get()
        {
            return catProdService.Get();
        }


        [HttpPost]
        public IActionResult Set(CategoriaProduto catProduto)
        {
            
            try
            {
                catProdService.Set(catProduto);
                return Ok();

            }catch(Exception ex)
            {
                return BadRequest("Erro: "+ex.Message);
            }

        }
    }
}
