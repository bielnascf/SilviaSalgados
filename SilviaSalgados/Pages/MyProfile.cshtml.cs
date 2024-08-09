using Business.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SilviaSalgadosWebApp.Models;
using System.Security.Claims;

namespace SilviaSalgadosWebApp.Pages
{
    public class MyProfileModel : PageModel
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public MyProfileModel(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        /*[BindProperty]
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
        public string Bairro { get; set; }*/

        public UsuarioViewModel UsuarioViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var usuario = await _usuarioBusiness.ObterUsuarioPorIdAsync(int.Parse(usuarioId));

            if (usuario == null)
            {
                return NotFound();
            }

            UsuarioViewModel.Nome = usuario.Nome;
            UsuarioViewModel.Email = usuario.Email;
            UsuarioViewModel.Senha = usuario.Senha;
            UsuarioViewModel.Celular = usuario.Celular;
            UsuarioViewModel.Rua = usuario.Rua;
            UsuarioViewModel.NumeroCasa = usuario.NumeroCasa;
            UsuarioViewModel.Cidade = usuario.Cidade;
            UsuarioViewModel.Bairro = usuario.Bairro;

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

            usuario.Nome = UsuarioViewModel.Nome;
            usuario.Email = UsuarioViewModel.Email;
            usuario.Senha = UsuarioViewModel.Senha;
            usuario.Celular = UsuarioViewModel.Celular;
            usuario.Rua = UsuarioViewModel.Rua;
            usuario.Bairro = UsuarioViewModel.Bairro;
            usuario.Cidade = UsuarioViewModel.Cidade;
            usuario.NumeroCasa = UsuarioViewModel.NumeroCasa;

            await _usuarioBusiness.AtualizarUsuario(usuario);

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Index");
        }
    }
}
