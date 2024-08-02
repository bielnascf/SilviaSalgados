using Business.Interface;
using Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {

        private readonly SilviaSalgadosDbContext _context;

        public UsuarioBusiness(SilviaSalgadosDbContext context)
        {
            _context = context;
        }

        public async void RegisterAsync(UsuarioEntity usuario)
        {
            var usuarioExistente = await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email);

            if (usuarioExistente)
            {
                throw new Exception("Usuário já existe!");
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioEntity> LoginAsync(string email, string senha)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public UsuarioEntity ObterUsuarioPorEmail(string email)
        {
            return _context.Usuarios.SingleOrDefault(u => u.Email == email);
        }

        public async Task<UsuarioEntity> ObterUsuarioPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public void AtualizarUsuario(UsuarioEntity usuario)
        {
            _context.Usuarios.Update(usuario);

            _context.SaveChanges();
        }
    }
}