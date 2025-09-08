using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Application.DTOs;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Application.Interfaces
{
    public interface IPedidosService
    {
        List<PedidoRetornoDTO> ListarTodos();
        PedidoRetornoDTO ListarPorId(int id);
        PedidoRetornoDTO CriarPedido(PedidoDTO pedidoDTO);
        PedidoRetornoDTO AtualizarStatus(int id, StatusDTO statusDTO);
        void CancelarPedido(int id);
    }
}