using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaqueroRecargaTelefonica.Models
{
    public class Recarga
    {
        public string NumeroTelefono { get; set; }
        public string Operador { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
