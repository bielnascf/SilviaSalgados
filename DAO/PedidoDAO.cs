using DAO.Interface;
using Entity;
using Infra.Context;

namespace DAO
{
    public class PedidoDAO : BaseDAO<PedidoEntity>, IPedidoDAO
    {
        private readonly SilviaSalgadosDbContext _context;

        public PedidoDAO(SilviaSalgadosDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
