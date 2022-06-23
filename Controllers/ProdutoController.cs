using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
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
    public class ProdutoController: ControllerBase
    {
        ProdutoService prodService = new ProdutoService();

        [HttpGet]
        [EnableQuery]
        public IQueryable<Produto> Get()
        {
            return prodService.Get();
        }


        [HttpPost]
        public IActionResult Set(Produto produto)
        {
            if (!prodService.ProdutoValidation(produto))
                return BadRequest("Verifique os dados enviados.");
            try
            {             
                return Ok(prodService.Set(produto));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Update(Produto produto)
        {
            if (!prodService.ProdutoValidation(produto) || produto.Id == 0 )
                return BadRequest("Verifique os dados enviados.");

            try
            {
                prodService.Update(produto);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(Produto produto)
        {
            if (produto.Id == 0)
                return BadRequest("Id não informado");
            try
            {
                prodService.Delete(produto);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }

        }
    }
}
