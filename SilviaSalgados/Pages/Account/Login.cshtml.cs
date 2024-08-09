using Business.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SilviaSalgadosWebApp.Models;
using System.Security.Claims;

namespace SilviaSalgadosWebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public LoginModel(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        /*[BindProperty]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Senha { get; set; }*/
        
        public UsuarioViewModel UsuarioViewModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _usuarioBusiness.LoginAsync(UsuarioViewModel.Email, UsuarioViewModel.Senha);

            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");

            return Page();
        }
    }
}
