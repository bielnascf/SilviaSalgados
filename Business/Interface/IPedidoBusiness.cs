﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IPedidoBusiness
    {
        public Task<PedidoEntity> CriarPedidoAsync(PedidoEntity pedido);
    }
}
