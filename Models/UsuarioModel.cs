﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UsuarioModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public string Rua { get; set; }
        public int NumeroCasa { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
    }
}
