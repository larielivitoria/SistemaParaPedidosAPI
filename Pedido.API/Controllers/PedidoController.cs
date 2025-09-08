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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidosService _pedidoService;
        public PedidoController(IPedidosService pedidosService)
        {
            _pedidoService = pedidosService;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var todos = _pedidoService.ListarTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var pedido = _pedidoService.ListarPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult CriarPedido([FromBody] PedidoDTO pedidoDTO)
        {
            var pedido = _pedidoService.CriarPedido(pedidoDTO);
            return CreatedAtAction(nameof(ListarTodos), new { id = pedido.ClienteId }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarStatus(int id, StatusDTO statusDTO)
        {
            var seExiste = _pedidoService.ListarPorId(id);
            if (seExiste == null)
            {
                return NotFound();
            }
            var existente = _pedidoService.AtualizarStatus(id, statusDTO);
            return Ok(existente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPedido(int id)
        {
            _pedidoService.CancelarPedido(id);
            return NoContent();
        }
    }
}