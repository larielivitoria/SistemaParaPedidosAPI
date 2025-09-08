using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PedidoAPI.Domain.Entities;
using PedidoAPI.Domain.Interfaces;
using PedidoAPI.Infrastructure.Db;

namespace PedidoAPI.Infrastructure.Repositorys
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context;
        public PedidoRepository(PedidoContext context)
        {
            _context = context;
        }

        public void CancelarPedido(int id)
        {
            var existe = _context.Pedidos.Find(id);
            if (existe != null)
            {
                _context.Pedidos.Remove(existe);
            }
        }

        public Pedido CriarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            return pedido;
        }

        public Pedido? ListarPorId(int id)
        {
            return _context.Pedidos
            .Where(p => p.Id == id)
            .Include(p => p.ItensDoPedido)
            .FirstOrDefault(p => p.Id == id);
        }

        public List<Pedido> ListarTodos()
        {
            var lista = _context.Pedidos.Include(p => p.ItensDoPedido).ToList();
            return lista;
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}