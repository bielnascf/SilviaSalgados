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
        public int? PedidoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TipoSalgado { get; set; } 
        public string ImagemURL { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoTotal { get; set; } 
        public SalgadoEntity Salgado { get; set; }
        public PedidoEntity Pedido { get; set; }
    }
}
