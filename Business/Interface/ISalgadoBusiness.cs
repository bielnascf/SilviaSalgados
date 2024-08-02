using Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ISalgadoBusiness
    {
        Task<IList<SalgadoEntity>> ObterSalgadosPorTipoAsync(string tipo);
        public Task<List<SalgadoEntity>> GetAllSalgadosAsync();
        Task<SalgadoEntity> ObterSalgadoPorIdAsync(int id);
    }
}
