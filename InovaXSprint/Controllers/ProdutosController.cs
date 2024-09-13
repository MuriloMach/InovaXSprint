﻿using InovaXSprint.Models;
using InovaXSprint.Repository; 
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InovaXSprint.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IRepository<Produto> _produtoRepository;

        public ProdutosController(IRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Produto produto)
        {
            _produtoRepository.Add(produto);
            return CreatedAtAction(nameof(GetAll), new { id = produto.IdProduto }, produto);
        }

        [HttpGet("v1/produto")]
        [ProducesResponseType(typeof(List<Produto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var produtos = _produtoRepository.GetAll();
            return Ok(produtos);
        }

        [HttpPatch("v1/produto")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Produto produto)
        {
            _produtoRepository.Update(produto);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Produto produto)
        {
            _produtoRepository.Delete(produto);
            return Ok();
        }
    }
}
