using Business.Interface;
using Models;
using Infra.Context;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class SalgadoBusiness : ISalgadoBusiness
    {
        private readonly SilviaSalgadosDbContext _context;

        public SalgadoBusiness(SilviaSalgadosDbContext context)
        {
            _context = context;
        }

        public async Task<IList<SalgadoEntity>> ObterSalgadosPorTipoAsync(string tipo)
        {
            return await _context.Salgados.Where(s => s.TipoSalgado == tipo).ToListAsync();
        }

        public async Task<SalgadoEntity> ObterSalgadoPorIdAsync(int id)
        {
            return await _context.Salgados.FindAsync(id);
        }

        public async Task<List<SalgadoEntity>> GetAllSalgadosAsync()
        {
            return await _context.Salgados.ToListAsync();
        }

    }
}
