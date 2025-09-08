using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoAPI.Domain.Entities
{
    public class Pedido
    {
        public Pedido(int clienteId, string status)
        {
            ClienteId = clienteId;
            Status = status;
            ItensDoPedido = new List<ProdutoInPedido>();
        }
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Data { get; set; }
        
        [Required]
        public string Status { get; set; }

        [Required]
        public List<ProdutoInPedido> ItensDoPedido { get; set; } = new List<ProdutoInPedido>();
    }
}