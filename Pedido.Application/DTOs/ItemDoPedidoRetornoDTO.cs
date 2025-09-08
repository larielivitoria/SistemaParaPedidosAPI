using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoAPI.Application.DTOs
{
    public class ItemDoPedidoRetornoDTO
    {
        public ItemDoPedidoRetornoDTO()
        {
            
        }
        public ItemDoPedidoRetornoDTO(int produtoId, int quantidadeProduto, decimal precoUnitario)
        {
            ProdutoId = produtoId;
            QuantidadeDeProduto = quantidadeProduto;
            ValorTotal = precoUnitario;
        }
        public int ProdutoId { get; set; }
        public int QuantidadeDeProduto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}