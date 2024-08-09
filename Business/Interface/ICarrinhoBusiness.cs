using Entity;
using Models;

namespace Business.Interface
{
    public interface ICarrinhoBusiness
    {
        public Task<int> ContarItensCarrinhoAsync(int usuarioId);
        public Task AdicionarItemAsync(ItemCarrinhoEntity item);
        public Task<ItemCarrinhoEntity> ObterItemCarrinhoAsync(string usuarioId, int salgadoId);
        public Task<List<ItemCarrinhoEntity>> ObterItensCarrinhoAsync(int usuarioId);
        public Task RemoverItemAsync(int usuarioId, int itemId);
        public Task LimparCarrinhoAsync(int usuarioId);
        public Task AtualizarItemAsync(ItemCarrinhoEntity itemCarrinho);

    }
}
