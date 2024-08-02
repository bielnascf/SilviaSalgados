using System.ComponentModel.DataAnnotations;

namespace SilviaSalgadosWebApp.Models
{
    public class SalgadoViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }

        [Required]
        public string TipoSalgado { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public string Imagem { get; set; }
    }
}
