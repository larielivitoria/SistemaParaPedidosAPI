using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PedidoAPI.Domain.Entities;
using PedidoAPI.Domain.Interfaces;
using PedidoAPI.Infrastructure.Db;

namespace PedidoAPI.Infrastructure.Repositorys
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _context;
        public ProdutoRepository(PedidoContext context)
        {
            _context = context;
        }


        public Produto CriarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            return produto;
        }

        public void DeletarProduto(int id)
        {
            var remover = _context.Produtos.Find(id);
            if (remover != null)
            {
                _context.Produtos.Remove(remover);
            }
        }

        public Produto? ListarPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public List<Produto> ListarTodos()
        {
            var lista = _context.Produtos.ToList();
            return lista;
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}