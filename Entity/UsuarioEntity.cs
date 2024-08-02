﻿using System.ComponentModel.DataAnnotations;

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
        public string NumeroCasa { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }

        public ICollection<PedidoEntity> Pedidos { get; set; }
    }
}
