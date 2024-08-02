using Business;
using Business.Interface;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using System.ComponentModel.DataAnnotations;

namespace SilviaSalgadosWebApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

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

            var usuario = new UsuarioEntity
            {
                Nome = Nome,
                Email = Email,
                Senha = Senha,
                Celular = Celular,
                Rua = Rua,
                NumeroCasa = NumeroCasa,
                Cidade = Cidade,
                Bairro = Bairro
            };

            _usuarioBusiness.RegisterAsync(usuario);

            return RedirectToPage("/Account/Login");
        }
    }
}
