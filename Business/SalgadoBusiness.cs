using Business.Interface;
using Models;
using Infra.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using DAO.Interface;

namespace Business
{
    public class SalgadoBusiness : ISalgadoBusiness
    {

        private readonly ISalgadoDAO _salgadoDAO;

        public SalgadoBusiness(ISalgadoDAO salgadoDAO)
        {
            _salgadoDAO = salgadoDAO;
        }

        public async Task<IList<SalgadoEntity>> ObterSalgadosPorTipoAsync(string tipo)
        {
            var salgadosObtidosPorTipo = await _salgadoDAO.ListarPor(s => s.TipoSalgado == tipo).ToListAsync();

            return salgadosObtidosPorTipo;
        }

        public async Task<SalgadoEntity> ObterSalgadoPorIdAsync(int id)
        {
            var salgadoObtidoPorId = await _salgadoDAO.ListarPor(s => s.Id == id).SingleOrDefaultAsync();

            return salgadoObtidoPorId;
        }

        public async Task<List<SalgadoEntity>> GetAllSalgadosAsync()
        {
            var salgados = await _salgadoDAO.Listar().ToListAsync();

            return salgados;
        }

    }
}
