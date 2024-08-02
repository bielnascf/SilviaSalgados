using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infra.Context;
using DAO.Interface;
using System.Linq.Expressions;

namespace DAO
{
    public class BaseDAO<TEntidade> : IBaseDAO<TEntidade> where TEntidade : class
    {
        private readonly SilviaSalgadosDbContext _context;

        public BaseDAO(SilviaSalgadosDbContext context)
        {
            _context = context;
        }

        public void Criar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Add(entidade);
        }

        public void Editar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Update(entidade);
        }

        public void Excluir(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntidade> Listar()
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            return query;
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
