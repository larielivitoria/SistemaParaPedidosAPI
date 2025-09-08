using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> ListarTodos();
        Pedido ListarPorId(int id);
        Pedido CriarPedido(Pedido pedido);
        void CancelarPedido(int id);

        void Salvar();
    }
}