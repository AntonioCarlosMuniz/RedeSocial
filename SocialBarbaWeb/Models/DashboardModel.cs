using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialBarbaWeb.Models
{
    // Entidade responsável por conter os dados que montam a tela principal
    public class DashboardModel
    {
        public string UserId { get; set; }
        public int idPerfil { get; set; }
        public string nomePerfil { get; set; }
        public string fotoPerfil { get; set; }
        public int TotPostagens { get; set; }
        public bool ChecaSeSeguePerfil { get; set; }
        public List<PostagemViewModel> postagens { get; set; }
        public List<PostagemViewModel> postagensSeguidos { get; set; }
        public List<Perfil> PerfisSeguidos { get; set; }
        public List<Perfil> PerfisSeguidores { get; set; }
        public List<BarbaViewModel> BarbasSeguidas { get; set; }
        public List<BarbaViewModel> Barbas { get; set; }
        public List<Barba> BigodesSeguidas { get; set; }
    }
}