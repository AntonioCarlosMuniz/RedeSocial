using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dominio
{
    public class Bigode
    {
        public int id { get; set; }
        public string Nome { get; set; }

        public int BarbaId { get; set; }
        public virtual Barba barba { get; set; }
    }
}
