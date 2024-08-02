using Business;
using Business.Interface;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace SilviaSalgadosWebApp.Pages.Cardapio
{
    public class CarrinhoModel : PageModel
    {
        private readonly ICarrinhoBusiness _carrinhoBusiness;
        private readonly IPedidoBusiness _pedidoBusiness;

        public CarrinhoModel(ICarrinhoBusiness carrinhoBusiness, IPedidoBusiness pedidoBusiness)
        {
            _carrinhoBusiness = carrinhoBusiness;
            _pedidoBusiness = pedidoBusiness;
        }

        public IList<ItemCarrinhoEntity> ItensCarrinho { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TaxaEntrega { get; set; } = 10.00m;
        public decimal Total { get; set; }
        [BindProperty]
        public string FormaPagamento { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ItensCarrinho = await _carrinhoBusiness.ObterItensCarrinhoAsync(int.Parse(usuarioId));

                Subtotal = ItensCarrinho.Sum(item => item.PrecoTotal);
                Total = Subtotal + TaxaEntrega;

                return Page();
            }

            return RedirectToPage("/Account/Login");
        }
        public async Task<IActionResult> OnPostRemoverItemAsync(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _carrinhoBusiness.RemoverItemAsync(int.Parse(userId), id);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostLimparCarrinhoAsync()
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _carrinhoBusiness.LimparCarrinhoAsync(int.Parse(usuarioId));

            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostFinalizarPedidoAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login");
            }

            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var itensCarrinho = await _carrinhoBusiness.ObterItensCarrinhoAsync(int.Parse(usuarioId));

            var pedido = new PedidoEntity
            {
                UsuarioId = int.Parse(usuarioId),
                DataPedido = DateTime.Now,
                FormaPagamento = FormaPagamento,
                Subtotal = Subtotal,
                TaxaEntrega = 10,
                Total = itensCarrinho.Sum(i => i.PrecoTotal) + 10
            };

            await _carrinhoBusiness.LimparCarrinhoAsync(int.Parse(usuarioId));

            return new JsonResult(new { success = pedido });
        }
    }
}
