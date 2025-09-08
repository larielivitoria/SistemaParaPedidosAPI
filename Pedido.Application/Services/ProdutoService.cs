using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Application.DTOs;
using PedidoAPI.Application.Interfaces;
using PedidoAPI.Domain.Entities;
using PedidoAPI.Domain.Interfaces;

namespace PedidoAPI.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Produto CriarProduto(ProdutoDTO produtoDTO)
        {
            var produtoNovo = new Produto(produtoDTO.Nome, produtoDTO.Descricao, produtoDTO.Preco, produtoDTO.Estoque);
            _repository.CriarProduto(produtoNovo);
            _repository.Salvar();
            return produtoNovo;
        }

        public void DeletarProduto(int id)
        {
            var seExiste = _repository.ListarPorId(id);
            if (seExiste == null)
            {
                throw new Exception($"Produto de Id {id} não encontrado.");
            }
            _repository.DeletarProduto(id);
            _repository.Salvar();
        }

        public Produto EditarProduto(int id, ProdutoDTO produtoDTO)
        {
            var existe = _repository.ListarPorId(id);

            if (existe == null)
            {
                throw new Exception($"Produto de Id {id} não encontrado.");
            }

            existe.Descricao = produtoDTO.Descricao;
            existe.Estoque = produtoDTO.Estoque;
            existe.Nome = produtoDTO.Nome;
            existe.Preco = produtoDTO.Preco;

            _repository.Salvar();
            return existe;
        }

        public Produto ListarPorId(int id)
        {
            var existe = _repository.ListarPorId(id);
            if (existe == null)
            {
                throw new Exception($"Produto de Id {id} não encontrado.");
            }

            return existe;
        }

        public List<Produto> ListarTodos()
        {
            var lista = _repository.ListarTodos();
            return lista;
        }
    }
}