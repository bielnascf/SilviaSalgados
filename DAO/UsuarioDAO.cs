using DAO.Interface;
using Entity;
using Infra.Context;

namespace DAO
{
    public class UsuarioDAO : BaseDAO<UsuarioEntity>, IUsuarioDAO
    {
        private readonly SilviaSalgadosDbContext _context;

        public UsuarioDAO(SilviaSalgadosDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
