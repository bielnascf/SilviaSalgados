using Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemCarrinho : IItemCarrinho
    {
        public int SalgadoId { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string SalgadoType { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public double ItemTotalPrice()
        {
            if (SalgadoType == "Frito" && Quantity == 25)
            {
                return 15;
            }
            if (SalgadoType == "Frito" && Quantity == 50)
            {
                return 25;
            }
            if (SalgadoType == "Frito" && Quantity == 75)
            {
                return 45;
            }
            if (SalgadoType == "Frito" && Quantity == 100)
            {
                return 60;
            }

            if (SalgadoType == "Assado" && Quantity == 25)
            {
                return 25;
            }
            if (SalgadoType == "Assado" && Quantity == 50)
            {
                return 40;
            }
            if (SalgadoType == "Assado" && Quantity == 75)
            {
                return 55;
            }
            if (SalgadoType == "Assado" && Quantity == 100)
            {
                return 75;
            }

            if (SalgadoType == "Especial" && Quantity == 25)
            {
                return 20;
            }
            if (SalgadoType == "Especial" && Quantity == 50)
            {
                return 35;
            }
            if (SalgadoType == "Especial" && Quantity == 75)
            {
                return 45;
            }
            if (SalgadoType == "Especial" && Quantity == 100)
            {
                return 65;
            }

            return 0;
        }
    }
}
