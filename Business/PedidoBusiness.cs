using Business.Interface;
using Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PedidoBusiness : IPedidoBusiness
    {
        private readonly SilviaSalgadosDbContext _context;
        private readonly ICarrinhoBusiness _carrinhoBusiness;

        public PedidoBusiness(SilviaSalgadosDbContext context, ICarrinhoBusiness carrinhoBusiness)
        {
            _context = context;
            _carrinhoBusiness = carrinhoBusiness;
        }

        public Task CriarPedidoAsync(PedidoEntity pedido)
        {
            _context.Pedidos.Add(pedido);
            return _context.SaveChangesAsync();
        }
    }
}
