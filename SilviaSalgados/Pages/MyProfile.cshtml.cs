using Business;
using Business.Interface;
using Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace SilviaSalgadosWebApp.Pages
{
    public class MyProfileModel : PageModel
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public MyProfileModel(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        [BindProperty]
        public string Nome { get; set; }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Senha { get; set; }

        [BindProperty]
        public string Celular { get; set; }

        [BindProperty]
        public string Rua { get; set; }

        [BindProperty]
        public string NumeroCasa { get; set; }

        [BindProperty]
        public string Cidade { get; set; }

        [BindProperty]
        public string Bairro { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var usuario = await _usuarioBusiness.ObterUsuarioPorIdAsync(int.Parse(usuarioId));

            if (usuario == null)
            {
                return NotFound();
            }

            Nome = usuario.Nome;
            Email = usuario.Email;
            Senha = usuario.Senha;
            Celular = usuario.Celular;
            Rua = usuario.Rua;
            NumeroCasa = usuario.NumeroCasa;
            Cidade = usuario.Cidade;
            Bairro = usuario.Bairro;

            return Page();
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var usuario = await _usuarioBusiness.ObterUsuarioPorIdAsync(int.Parse(usuarioId));

            usuario.Nome = Nome;
            usuario.Email = Email;
            usuario.Senha = Senha;
            usuario.Celular = Celular;
            usuario.Rua = Rua;
            usuario.Bairro = Bairro;
            usuario.Cidade = Cidade;
            usuario.NumeroCasa = NumeroCasa;

            _usuarioBusiness.AtualizarUsuario(usuario);

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Index");
        }
    }
}
