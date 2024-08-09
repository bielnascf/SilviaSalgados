using Business.Interface;
using DAO.Interface;
using Entity;
using Infra.Context;

namespace Business
{
    public class PedidoBusiness : IPedidoBusiness
    {
        private readonly SilviaSalgadosDbContext _context;
        private readonly IPedidoDAO _pedidoDAO;

        public PedidoBusiness(SilviaSalgadosDbContext context, IPedidoDAO pedidoDAO)
        {
            _context = context;
            _pedidoDAO = pedidoDAO;
        }

        public async Task<PedidoEntity> CriarPedidoAsync(PedidoEntity pedido)
        {
            _pedidoDAO.Criar(pedido);

            await _context.SaveChangesAsync();

            return pedido;
        }
    }
}
