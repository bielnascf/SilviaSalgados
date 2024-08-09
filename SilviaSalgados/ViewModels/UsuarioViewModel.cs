using System.ComponentModel.DataAnnotations;

namespace SilviaSalgadosWebApp.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Esse Campo é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Esse Campo é obrigatório!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Esse Campo é obrigatório!")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        public string Senha { get; set; }
        [RegularExpression("^\\(?[1-9]{2}\\)? ?(?:[2-8]|9[0-9])[0-9]{3}\\-?[0-9]{4}$", ErrorMessage = "Digite um número Válido!")]
        [Required(ErrorMessage = "Esse Campo é obrigatório!")]
        [Phone(ErrorMessage = "Digite um número Válido!")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Esse Campo é obrigatório!")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Esse Campo é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "Adicione um número válido!")]
        public int NumeroCasa { get; set; }
        [Required(ErrorMessage = "Esse Campo é obrigatório!")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Esse Campo é obrigatório!")]
        public string Bairro { get; set; }
    }
}
