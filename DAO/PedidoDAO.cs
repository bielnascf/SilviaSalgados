using DAO.Interface;
using Entity;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
