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

            try
            {             
                return Ok(prodService.Set(produto));

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult Update(Produto produto)
        {
            try
            {
                prodService.Update(produto);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public IActionResult Delete(Produto produto)
        {
            try
            {
                prodService.Delete(produto);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
