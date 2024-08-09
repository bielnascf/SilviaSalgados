using Models;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public string Rua { get; set; }
        public int NumeroCasa { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }

        public ICollection<PedidoEntity> Pedidos { get; set; }

        public static explicit operator UsuarioModel(UsuarioEntity source)
        {
            if (source != null)
            {
                return new UsuarioModel()
                {
                    Nome = source.Nome,
                    Email = source.Email,
                    Senha = source.Senha,
                    Celular = source.Celular,
                    Rua = source.Rua,
                    NumeroCasa = source.NumeroCasa,
                    Cidade = source.Cidade,
                    Bairro = source.Bairro,
                };
            }
            else
            {
                return null;
            }
        }

        public static explicit operator UsuarioEntity(UsuarioModel source)
        {
            if (source != null)
            {
                return new UsuarioEntity()
                {
                    Nome = source.Nome,
                    Email = source.Email,
                    Senha = source.Senha,
                    Celular = source.Celular,
                    Rua = source.Rua,
                    NumeroCasa = source.NumeroCasa,
                    Cidade = source.Cidade,
                    Bairro = source.Bairro,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
