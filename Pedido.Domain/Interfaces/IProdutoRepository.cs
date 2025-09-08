using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> ListarTodos();
        Produto ListarPorId(int id);
        Produto CriarProduto(Produto produto);
        void DeletarProduto(int id);

        void Salvar();
    }
}