using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Application.DTOs;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Application.Interfaces
{
    public interface IProdutoService
    {
        List<Produto> ListarTodos();
        Produto ListarPorId(int id);
        Produto CriarProduto(ProdutoDTO produtoDTO);
        Produto EditarProduto(int id, ProdutoDTO produtoDTO);
        void DeletarProduto(int id);
    }
}