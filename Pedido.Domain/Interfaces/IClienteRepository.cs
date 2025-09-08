using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Domain.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();
        Cliente RegistrarCliente(Cliente cliente);
        Cliente ListarPorId(int id);
        void ApagarCliente(int id);

        void Salvar();
    }
}