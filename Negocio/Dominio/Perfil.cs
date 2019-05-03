using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dominio
{
    public class Perfil
    {
        public int id { get; set; }
        public string UserID { get; set; }
        public string NomeExibicao { get; set; }
        public string FotoPerfil { get; set; }
    }
}