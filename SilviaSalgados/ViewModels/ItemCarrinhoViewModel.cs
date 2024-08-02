using System.ComponentModel.DataAnnotations;

namespace SilviaSalgadosWebApp.ViewModels
{
    public class ItemCarrinhoViewModel
    {
        public int UsuarioId { get; set; }
        public int SalgadoId { get; set; }
        public int? PedidoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TipoSalgado { get; set; }
        public string ImagemURL { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }
    }
}
