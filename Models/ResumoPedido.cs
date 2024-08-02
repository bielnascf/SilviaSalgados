using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ResumoPedido
    {
        public double Subtotal { get; set; }
        public double TaxaEntrega { get; set; } = 10.00;
        public string FormaPagamento { get; set; }
        public double Total { get; set; }
    }
}
