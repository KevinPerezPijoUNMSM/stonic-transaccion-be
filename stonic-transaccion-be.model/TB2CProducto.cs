using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stonic_transaccion_be.model
{
    public class TB2CProducto
    {
        public int IdTransaccionB2C { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
