using Business.Interface;
using DAO.Interface;
using Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {

        private readonly IUsuarioDAO _usuarioDAO;

        private readonly SilviaSalgadosDbContext _context;

        public UsuarioBusiness(IUsuarioDAO usuarioDAO, SilviaSalgadosDbContext context)
        {
            _usuarioDAO = usuarioDAO;
            _context = context;
        }

        public async Task RegisterAsync(UsuarioModel usuario)
        {

            var usuarioExistente = await _usuarioDAO.ListarPor(u => u.Email == usuario.Email).SingleOrDefaultAsync();

            if (usuarioExistente != null)
            {
                throw new Exception("Usuário já existe!");
            }

            var usuarioEntity = (UsuarioEntity)usuario;

            _usuarioDAO.Criar(usuarioEntity);

            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioEntity> LoginAsync(string email, string senha)
        {
            var usuario = await _usuarioDAO.ListarPor(u => u.Email == email && u.Senha == senha).SingleOrDefaultAsync();

            return usuario;
        }

        public async Task<UsuarioEntity> ObterUsuarioPorEmail(string email)
        {
            var usuarioObtidoPorEmail = await _usuarioDAO.ListarPor(u => u.Email == email).SingleOrDefaultAsync();

            return usuarioObtidoPorEmail;
        }

        public async Task<UsuarioEntity> ObterUsuarioPorIdAsync(int id)
        {
            var usuarioObtidoPorId = await _usuarioDAO.ListarPor(u => u.Id == id).SingleOrDefaultAsync();

            return usuarioObtidoPorId;
        }

        public async Task AtualizarUsuario(UsuarioEntity usuario)
        {
            _usuarioDAO.Editar(usuario);

            await _context.SaveChangesAsync();
        }
    }
}