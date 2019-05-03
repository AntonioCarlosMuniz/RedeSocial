using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialBarbaWeb.Models
{
    // Entidade que representa todos os dados necessários para a pagina 'Toda a Rede'
    public class RedeModel
    {
        public int TotTotasAsPostagens { get; set; }
        public List<PostagemViewModel> TodasAsPostagens { get; set; }
        public List<Perfil> TodosOsPerfis { get; set; }
        public List<Barba> TodasBarbas { get; set; }
        public List<Bigode> TodasOsBigodes { get; set; }
    }
}