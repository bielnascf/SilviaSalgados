using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PedidoEntity
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public DateTime DataPedido { get; set; } = DateTime.Now;

        public string FormaPagamento { get; set; }

        public decimal Subtotal { get; set; }
        public decimal TaxaEntrega { get; set; } = 10.00m;
        public decimal Total { get; set; }

        public UsuarioEntity Usuario { get; set; }

        public ICollection<ItemCarrinhoEntity> ItensCarrinhos { get; set; }
    }
}
