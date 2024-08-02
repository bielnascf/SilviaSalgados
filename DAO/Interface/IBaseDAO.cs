using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    public interface IBaseDAO<TEntidade> where TEntidade : class
    {
        public void Criar(TEntidade entidade);
        public void Editar(TEntidade entidade);
        public void Excluir(TEntidade entidade);
        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);
        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);
    }
}
