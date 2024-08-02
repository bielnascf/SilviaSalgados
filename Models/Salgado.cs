using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Salgado
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SalgadoType { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}
