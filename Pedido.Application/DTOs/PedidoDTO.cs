using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Application.DTOs
{
    public class PedidoDTO
    {
        public int ClienteId { get; set; }
        public string Status { get; set; }
        public List<ItemDoPedidoDTO> ItensDoPedido { get; set; }
        
    }
}