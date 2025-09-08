using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoAPI.Application.DTOs
{
    public class PedidoRetornoDTO
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public string Status { get; set; }
        public List<ItemDoPedidoRetornoDTO> ItensDoPedido { get; set; } = new List<ItemDoPedidoRetornoDTO>();
    }
}