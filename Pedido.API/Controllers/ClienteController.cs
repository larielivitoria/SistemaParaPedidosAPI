using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PedidoAPI.Application.DTOs;
using PedidoAPI.Application.Interfaces;
using PedidoAPI.Domain.Entities;

namespace Pedido.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var lista = _clienteService.ListarTodos();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var cliente = _clienteService.ListarPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult RegistrarCliente([FromBody] ClienteDTO clienteDTO)
        {
            var cliente = _clienteService.RegistrarCliente(clienteDTO);
            return CreatedAtAction(nameof(ListarTodos), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] ClienteDTO clienteDTO)
        {
            var seExiste = _clienteService.ListarPorId(id);
            if (seExiste == null)
            {
                return NotFound();
            }
            var existente = _clienteService.AtualizarCliente(id, clienteDTO);
            return Ok(existente);
        }

        [HttpDelete("{id}")]
        public IActionResult ApagarCliente(int id)
        {
            _clienteService.ApagarCliente(id);
            return NoContent();
        }
    }
}