using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using SilviaSalgadosWebApp.Models;

namespace SilviaSalgadosWebApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUsuarioBusiness _usuarioBusiness;
/*
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
        public string Bairro { get; set; }*/

        public UsuarioViewModel UsuarioViewModel { get; set; }

        public RegisterModel(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuario = new UsuarioModel
            {
                Nome = UsuarioViewModel.Nome,
                Email = UsuarioViewModel.Email,
                Senha = UsuarioViewModel.Senha,
                Celular = UsuarioViewModel.Celular,
                Rua = UsuarioViewModel.Rua,
                NumeroCasa = UsuarioViewModel.NumeroCasa,
                Cidade = UsuarioViewModel.Cidade,
                Bairro = UsuarioViewModel.Bairro
            };

            await _usuarioBusiness.RegisterAsync(usuario);

            return RedirectToPage("/Account/Login");
        }
    }
}
