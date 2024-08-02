using Business;
using Business.Interface;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace SilviaSalgadosWebApp.Pages.Cardapio
{
    public class DetailsModel : PageModel
    {
        private readonly ISalgadoBusiness _salgadoBusiness;
        private readonly ICarrinhoBusiness _carrinhoBusiness;

        public DetailsModel(ISalgadoBusiness salgadoBusiness, ICarrinhoBusiness carrinhoBusiness)
        {
            _salgadoBusiness = salgadoBusiness;
            _carrinhoBusiness = carrinhoBusiness;
        }

        [BindProperty]
        public int Quantidade { get; set; }
        public SalgadoEntity Salgado { get; set; }
        public ItemCarrinhoEntity ItemCarrinho { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Salgado = await _salgadoBusiness.ObterSalgadoPorIdAsync(id);

            if(Salgado == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login");
            }

            Salgado = await _salgadoBusiness.ObterSalgadoPorIdAsync(id);

            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var precoTotal = 0;

            if (Salgado.TipoSalgado == "Frito")
            {
                switch (Quantidade)
                {
                    case 25:
                        precoTotal = 15;
                        break;
                    case 50:
                        precoTotal = 25;
                        break;
                    case 75:
                        precoTotal = 45;
                        break;
                    case 100:
                        precoTotal = 60;
                        break;
                }
            }
            else if (Salgado.TipoSalgado == "Assado")
            {
                switch (Quantidade)
                {
                    case 25:
                        precoTotal = 25;
                        break;
                    case 50:
                        precoTotal = 40;
                        break;
                    case 75:
                        precoTotal = 55;
                        break;
                    case 100:
                        precoTotal = 75;
                        break;
                }
            }
            else if (Salgado.TipoSalgado == "Especial")
            {
                switch (Quantidade)
                {
                    case 25:
                        precoTotal = 20;
                        break;
                    case 50:
                        precoTotal = 35;
                        break;
                    case 75:
                        precoTotal = 45;
                        break;
                    case 100:
                        precoTotal = 65;
                        break;
                }
            }

            var itemExistente = await _carrinhoBusiness.ObterItemCarrinhoAsync(usuarioId, Salgado.Id);

            if (itemExistente != null)
            {
                itemExistente.Quantidade += Quantidade;

                var novoPrecoTotal = 0;

                if (Salgado.TipoSalgado == "Frito")
                {
                    switch (itemExistente.Quantidade)
                    {
                        case 25:
                            novoPrecoTotal = 15;
                            break;
                        case 50:
                            novoPrecoTotal = 25;
                            break;
                        case 75:
                            novoPrecoTotal = 45;
                            break;
                        case 100:
                            novoPrecoTotal = 60;
                            break;
                    }
                }
                else if (Salgado.TipoSalgado == "Assado")
                {
                    switch (itemExistente.Quantidade)
                    {
                        case 25:
                            novoPrecoTotal = 25;
                            break;
                        case 50:
                            novoPrecoTotal = 40;
                            break;
                        case 75:
                            novoPrecoTotal = 55;
                            break;
                        case 100:
                            novoPrecoTotal = 75;
                            break;
                    }
                }
                else if (Salgado.TipoSalgado == "Especial")
                {
                    switch (itemExistente.Quantidade)
                    {
                        case 25:
                            novoPrecoTotal = 20;
                            break;
                        case 50:
                            novoPrecoTotal = 35;
                            break;
                        case 75:
                            novoPrecoTotal = 45;
                            break;
                        case 100:
                            novoPrecoTotal = 65;
                            break;
                    }
                }

                itemExistente.PrecoTotal = novoPrecoTotal;

                await _carrinhoBusiness.AtualizarItemAsync(itemExistente);
            }
            else
            {
                ItemCarrinho = new ItemCarrinhoEntity
                {
                    UsuarioId = int.Parse(usuarioId),
                    SalgadoId = Salgado.Id,
                    Nome = Salgado.Nome,
                    Descricao = Salgado.Descricao,
                    TipoSalgado = Salgado.TipoSalgado,
                    ImagemURL = Salgado.Imagem,
                    Quantidade = Quantidade,
                    PrecoTotal = precoTotal
                };

                await _carrinhoBusiness.AdicionarItemAsync(ItemCarrinho);
            }

            return RedirectToPage("/Cardapio/index");

        }
    }
}
