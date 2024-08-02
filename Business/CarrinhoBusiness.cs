using Business.Interface;
using Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Business
{
    public class CarrinhoBusiness : ICarrinhoBusiness
    {
        private readonly SilviaSalgadosDbContext _context;

        public CarrinhoBusiness(SilviaSalgadosDbContext context)
        {
            _context = context;
        }

        public async Task<int> ContarItensCarrinhoAsync(int usuarioId)
        {
            return await _context.ItensCarrinho.CountAsync(i => i.UsuarioId == usuarioId);
        }
       
        public Task AdicionarItemAsync(ItemCarrinhoEntity item)
        {
            _context.ItensCarrinho.Add(item);
            return _context.SaveChangesAsync();
        }

        public async Task<ItemCarrinhoEntity> ObterItemCarrinhoAsync(string usuarioId, int salgadoId)
        {
            return await _context.ItensCarrinho
                .Where(i => i.UsuarioId == int.Parse(usuarioId) && i.SalgadoId == salgadoId)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<ItemCarrinhoEntity>> ObterItensCarrinhoAsync(int usuarioId)
        {
            return await _context.ItensCarrinho.Where(i => i.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task RemoverItemAsync(int usuarioId, int itemId)
        {
            var item = await _context.ItensCarrinho
                .Where(i => i.UsuarioId == usuarioId && i.Id == itemId)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                _context.ItensCarrinho.Remove(item);

                await _context.SaveChangesAsync();
            }
        }


        public Task LimparCarrinhoAsync(int usuarioId)
        {
            var itens = _context.ItensCarrinho.Where(i => i.UsuarioId == usuarioId);
            _context.ItensCarrinho.RemoveRange(itens);

            return _context.SaveChangesAsync();
        }

        public async Task AtualizarItemAsync(ItemCarrinhoEntity itemCarrinho)
        {
            _context.ItensCarrinho.Update(itemCarrinho);
            await _context.SaveChangesAsync();
        }
    }
}
