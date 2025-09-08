using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PedidoAPI.Application.DTOs;
using PedidoAPI.Application.Interfaces;

namespace Pedido.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var todos = _produtoService.ListarTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var produto = _produtoService.ListarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult CriarProduto(ProdutoDTO produtoDTO)
        {
            var produto = _produtoService.CriarProduto(produtoDTO);
            return CreatedAtAction(nameof(ListarTodos), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarProduto(int id, ProdutoDTO produtoDTO)
        {
            var existe = _produtoService.ListarPorId(id);
            if (existe == null)
            {
                return NotFound();
            }
            var existente = _produtoService.EditarProduto(id, produtoDTO);
            return Ok(existente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            _produtoService.DeletarProduto(id);
            return NoContent();
        }
    }
}