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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public void ApagarCliente(int id)
        {
            var existe = _repository.ListarPorId(id);
            if (existe == null)
            {
                throw new Exception($"Cliente de Id {id} não encontrado.");
            }
            _repository.ApagarCliente(id);
            _repository.Salvar();
        }

        public Cliente AtualizarCliente(int id, ClienteDTO clienteDTO)
        {
            var existe = _repository.ListarPorId(id);
            if (existe == null)
            {
                throw new Exception($"Cliente de Id {id} não encontrado.");
            }
            existe.Email = clienteDTO.Email;
            existe.Endereco = clienteDTO.Endereco;
            existe.Nome = clienteDTO.Nome;
            existe.Telefone = clienteDTO.Telefone;

            _repository.Salvar();
            return existe;
        }

        public Cliente ListarPorId(int id)
        {
            var existe = _repository.ListarPorId(id);
            if (existe == null)
            {
                throw new Exception($"Cliente de Id {id} não encontrado.");
            }
            return existe;
        }

        public List<Cliente> ListarTodos()
        {
            return _repository.ListarTodos();
        }

        public Cliente RegistrarCliente(ClienteDTO clienteDTO)
        {
            var clienteNovo = new Cliente(clienteDTO.Nome, clienteDTO.Email, clienteDTO.Endereco, clienteDTO.Telefone);
            _repository.RegistrarCliente(clienteNovo);
            _repository.Salvar();
            return clienteNovo;
        }
    }
}