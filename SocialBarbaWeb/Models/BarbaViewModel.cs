using Dados;
using Negocio.Dominio;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialBarbaWeb.Models
{
    public class BarbaViewModel
    {
        private PerfilServico servicoPerfil;

        public BarbaViewModel()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
        }

        public int id { get; set; }
        public int PerfilID { get; set; }
        public string UserId { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime data { get; set; }
        public List<Bigode> Bigodes { get; set; }
        public int Capacidade { get; set; }

        public string UserName { get; set; }
        public string UserFoto { get; set; }

        // Metodo que recebe um do tipo barba e converte para barbaViewModel
        public void SetModel(Barba barba)
        {
            Perfil perfil = new Perfil();
            perfil = servicoPerfil.RetornaPerfilUnico(barba.PerfilID);

            id = barba.id;
            PerfilID = barba.PerfilID;
            data = barba.data;
            Nome = barba.nome;
            UserId = perfil.UserID;
            Capacidade = barba.capacidade;
            Tipo = barba.tipo;
            Bigodes = barba.Bigodes;

            UserName = perfil.NomeExibicao;
            UserFoto = perfil.FotoPerfil;
        }

        // Metodo que recebe uma lista do tipo barba e devolve uma lista de barbaViewModel
        public static List<BarbaViewModel> GetModel(List<Barba> barbas)
        {
            BarbaViewModel barbaView;
            List<BarbaViewModel> listaView = new List<BarbaViewModel>();

            foreach (Barba item in barbas)
            {
                barbaView = new BarbaViewModel();
                barbaView.SetModel(item);

                listaView.Add(barbaView);
            }
            return listaView;
        }

        // Metodo que recebe um objeto do tipo barba e devolve um objeto barbaViewModel
        public static BarbaViewModel GetModel(Barba barba)
        {
            BarbaViewModel barbaView = new BarbaViewModel();
            barbaView.SetModel(barba);
            return barbaView;
        }
    }
}