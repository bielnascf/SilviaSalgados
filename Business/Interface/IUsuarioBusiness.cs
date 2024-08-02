using Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IUsuarioBusiness
    {
        public Task RegisterAsync(UsuarioEntity usuario);
        public Task<UsuarioEntity> LoginAsync(string email, string senha);
        public Task<UsuarioEntity> ObterUsuarioPorEmail(string email);
        public Task<UsuarioEntity> ObterUsuarioPorIdAsync(int id);
        public Task AtualizarUsuario(UsuarioEntity usuario);
    }
}
