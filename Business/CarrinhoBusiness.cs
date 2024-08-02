using Business.Interface;
using DAO.Interface;
using Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Business
{
    public class CarrinhoBusiness : ICarrinhoBusiness
    {
        private readonly ICarrinhoDAO _carrinhoDAO;
        private readonly SilviaSalgadosDbContext _context;

        public CarrinhoBusiness(ICarrinhoDAO carrinhoDAO, SilviaSalgadosDbContext context)
        {
            _carrinhoDAO = carrinhoDAO;
            _context = context;
        }

        public async Task<int> ContarItensCarrinhoAsync(int usuarioId)
        {
            var itensCarrinho = await _carrinhoDAO.ListarPor(i => i.UsuarioId == usuarioId).ToListAsync();

            var contagemItensCarrinho = itensCarrinho.Count();

            return contagemItensCarrinho;
        }
       
        public async Task AdicionarItemAsync(ItemCarrinhoEntity item)
        {
            _carrinhoDAO.Criar(item);

            await _context.SaveChangesAsync();
        }

        public async Task<ItemCarrinhoEntity> ObterItemCarrinhoAsync(string usuarioId, int salgadoId)
        {
            var itemCarrinho = await _carrinhoDAO.ListarPor(i => i.UsuarioId == int.Parse(usuarioId) && i.SalgadoId == salgadoId).FirstOrDefaultAsync();

            return itemCarrinho;
        }

        public async Task<IList<ItemCarrinhoEntity>> ObterItensCarrinhoAsync(int usuarioId)
        {
            var itensCarrinho = await _carrinhoDAO.Listar().Where(i => i.UsuarioId == usuarioId).ToListAsync();

            return itensCarrinho;
        }

        public async Task RemoverItemAsync(int usuarioId, int itemId)
        {
            var item = await _carrinhoDAO.ListarPor(i => i.UsuarioId == usuarioId && i.Id == itemId).FirstOrDefaultAsync();

            if (item != null)
            {
                _carrinhoDAO.Excluir(item);

                await _context.SaveChangesAsync();
            }
        }

        public async Task LimparCarrinhoAsync(int usuarioId)
        {
            var itens = await _carrinhoDAO.ListarPor(i => i.UsuarioId == usuarioId).ToListAsync();

            _context.ItensCarrinho.RemoveRange(itens);

            await _context.SaveChangesAsync();
        }

        public async Task AtualizarItemAsync(ItemCarrinhoEntity itemCarrinho)
        {
            _carrinhoDAO.Editar(itemCarrinho);

            await _context.SaveChangesAsync();
        }
    }
}
