using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SalgadoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TipoSalgado { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public ICollection<ItemCarrinhoEntity> ItensCarrinhos { get; set; }
    }
}
