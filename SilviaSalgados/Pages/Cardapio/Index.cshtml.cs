using Business;
using Business.Interface;
using Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace SilviaSalgadosWebApp.Pages.Cardapio
{
    public class IndexModel : PageModel
    {

        private readonly ISalgadoBusiness _salgadoBusiness;
        private readonly ICarrinhoBusiness _carrinhoBusiness;

        public IndexModel(ISalgadoBusiness salgadoBusiness, ICarrinhoBusiness carrinhoBusiness)
        {
            _salgadoBusiness = salgadoBusiness;
            _carrinhoBusiness = carrinhoBusiness;
        }

        public IList<SalgadoEntity> Fritos { get; set; }
        public IList<SalgadoEntity> Assados { get; set; }
        public IList<SalgadoEntity> Especiais { get; set; }

        public int ContadorItensCarrinho { get; set; }

        public async Task OnGetAsync()
        {
            Fritos = await _salgadoBusiness.ObterSalgadosPorTipoAsync("Frito");
            Assados = await _salgadoBusiness.ObterSalgadosPorTipoAsync("Assado");
            Especiais = await _salgadoBusiness.ObterSalgadosPorTipoAsync("Especial");

            if(User.Identity.IsAuthenticated)
            {
                var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ContadorItensCarrinho = await _carrinhoBusiness.ContarItensCarrinhoAsync(int.Parse(usuarioId));
            }
        }
    }
}
