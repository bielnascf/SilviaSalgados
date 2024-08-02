using System.ComponentModel.DataAnnotations;

namespace SilviaSalgadosWebApp.Models
{
    public class PedidoViewModel
    {
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public string FormaPagamento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TaxaEntrega { get; set; } = 10.00m;
        public decimal Total { get; set; }
    }
}
