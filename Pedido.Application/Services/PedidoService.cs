using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using PedidoAPI.Application.DTOs;
using PedidoAPI.Application.Interfaces;
using PedidoAPI.Domain.Entities;
using PedidoAPI.Domain.Interfaces;

namespace PedidoAPI.Application.Services
{
    public class PedidoService : IPedidosService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public Pedido AtualizarStatus(int id, StatusDTO statusDTO)
        {
            var existe = _pedidoRepository.ListarPorId(id);
            if (existe == null)
            {
                throw new Exception("Pedido não existe.");
            }
            ;
            existe.Status = statusDTO.Status;
            _pedidoRepository.Salvar();
            return existe;
        }

        public void CancelarPedido(int id)
        {
            _pedidoRepository.CancelarPedido(id);
            _pedidoRepository.Salvar();
        }

        public PedidoRetornoDTO CriarPedido(PedidoDTO pedidoDTO)
        {
            var pedido = new Pedido(pedidoDTO.ClienteId, pedidoDTO.Status);
            
            pedido.ItensDoPedido = pedidoDTO.ItensDoPedido.Select(itemDto =>
            {
                var produto = _produtoRepository.ListarPorId(itemDto.ProdutoId);
                if (produto == null)
                {
                    throw new Exception($"Produto com Id {itemDto.ProdutoId} não encontrado");
                }
                return new ProdutoInPedido(
                    pedido: pedido,
                    produtoId: produto.Id,
                    quantidade: itemDto.Quantidade,
                    precoUnitario: produto.Preco
                );
            }).ToList();

            _pedidoRepository.CriarPedido(pedido);
            _pedidoRepository.Salvar();

            return new PedidoRetornoDTO
            {
                ClienteId = pedido.ClienteId,
                Status = pedido.Status,
                ItensDoPedido = pedido.ItensDoPedido.Select(i => new ItemDoPedidoRetornoDTO
                {
                    ProdutoId = i.ProdutoId,
                    QuantidadeDeProduto = i.QuantidadeDeProduto,
                    ValorTotal = i.ValorTotal
                }).ToList()
            };
        }

        public PedidoRetornoDTO ListarPorId(int id)
        {
            var pedido = _pedidoRepository.ListarPorId(id);
            var itens = pedido.ItensDoPedido.Select(itemDto =>
            {
                var produto = _produtoRepository.ListarPorId(itemDto.ProdutoId);
                if (produto == null)
                {
                    throw new Exception("Produto não existe.");
                }
            return new ItemDoPedidoRetornoDTO(
                produtoId: produto.Id,
                quantidadeProduto: itemDto.QuantidadeDeProduto,
                precoUnitario: itemDto.ValorTotal
                );
            }).ToList();

            return new PedidoRetornoDTO
            {
                PedidoId = pedido.Id,
                ClienteId = pedido.ClienteId,
                Status = pedido.Status,
                ItensDoPedido = itens
            };
        }

        public List<PedidoRetornoDTO> ListarTodos()
        {
            var pedidosDto = _pedidoRepository.ListarTodos()
            .Select(p => new PedidoRetornoDTO
            {
                PedidoId = p.Id,
                ClienteId = p.ClienteId,
                Status = p.Status,
                ItensDoPedido = p.ItensDoPedido.Select(i => new ItemDoPedidoRetornoDTO(
                    i.ProdutoId,
                    i.QuantidadeDeProduto,
                    i.ValorTotal
                )).ToList()
            }).ToList();

            return pedidosDto;
            
        }
    }
}