using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoAPI.Domain.Entities;
using PedidoAPI.Domain.Interfaces;
using PedidoAPI.Infrastructure.Db;

namespace PedidoAPI.Infrastructure.Repositorys
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PedidoContext _context;
        public ClienteRepository(PedidoContext context)
        {
            _context = context;
        }

        public void ApagarCliente(int id)
        {
            var existe = _context.Clientes.Find(id);
            if (existe != null)
            {
                _context.Clientes.Remove(existe);
            }
        }

        public Cliente? ListarPorId(int id)
        {
            var listar = _context.Clientes.Find(id);
            return listar;
        }

        public List<Cliente> ListarTodos()
        {
            var todos = _context.Clientes.ToList();
            return todos;
        }

        public Cliente RegistrarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            return cliente;
        }

        public void Salvar()
        {
           _context.SaveChanges();
        }
    }
}