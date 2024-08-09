using DAO.Interface;
using Entity;
using Infra.Context;

namespace DAO
{
    public class CarrinhoDAO : BaseDAO<ItemCarrinhoEntity>, ICarrinhoDAO
    {
        private readonly SilviaSalgadosDbContext _context;

        public CarrinhoDAO(SilviaSalgadosDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
