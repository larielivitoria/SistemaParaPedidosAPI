using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoAPI.Domain.Entities
{
    public class ProdutoInPedido
    {
        public ProdutoInPedido()
        {
            
        }
        public ProdutoInPedido(Pedido pedido, int produtoId, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            ProdutoId = produtoId;
            QuantidadeDeProduto = quantidade;
            ValorTotal = precoUnitario * quantidade;
        }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeDeProduto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}