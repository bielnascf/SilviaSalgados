using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ItemCarrinhoEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        [Required]
        public int SalgadoId { get; set; }

        public int? PedidoId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public string TipoSalgado { get; set; } 

        [Required]
        public string ImagemURL { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal PrecoTotal { get; set; } 

        public SalgadoEntity Salgado { get; set; }

        public PedidoEntity Pedido { get; set; }
    }
}
