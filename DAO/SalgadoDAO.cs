using DAO.Interface;
using Entity;
using Infra.Context;

namespace DAO
{
    public class SalgadoDAO : BaseDAO<SalgadoEntity>, ISalgadoDAO
    {
        private readonly SilviaSalgadosDbContext _context;

        public SalgadoDAO(SilviaSalgadosDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
