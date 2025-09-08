using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Application.DTOs;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Application.Interfaces
{
    public interface IClienteService
    {
        List<Cliente> ListarTodos();
        Cliente RegistrarCliente(ClienteDTO clienteDTO);
        Cliente ListarPorId(int id);
        Cliente AtualizarCliente(int id, ClienteDTO clienteDTO);
        void ApagarCliente(int id);
    }
}