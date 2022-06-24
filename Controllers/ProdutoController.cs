using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProdutoStoreApi.DTOs;
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
        readonly ProdutoService prodService = new();

        [HttpGet]
        [EnableQuery]
        public IQueryable<Produto> Get()
        {
            return prodService.Get();
        }


        [HttpPost]
        public IActionResult Set(Produto produto)
        {
            if (produto.Id > 0)
                return BadRequest("O Id é gerado automáticamente. revise os dados ou utilize o método de update");

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
            if (produto.Id == 0 )
                return BadRequest("Necessário informar o ID do produto a ser atualizado.");

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
        public IActionResult Delete(ProdutoDto produto)
        {
         
            if (produto.Id == 0)
                return BadRequest("Id não informado");
            try
            {
                prodService.Delete(produto.Id);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }

        }
    }
}
