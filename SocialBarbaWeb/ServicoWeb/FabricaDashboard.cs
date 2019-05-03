using Dados;
using Negocio.Dominio;
using Servico;
using SocialBarbaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialBarbaWeb.ServicoWeb
{
    public class FabricaDashboard
    {
        private PerfilServico servicoPerfil;
        private PostagemServico servicoPostagem;
        private SeguirServico servicoSeguir;
        private BarbaServico servicoBarba;

        public FabricaDashboard()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
            servicoSeguir = new SeguirServico(new SeguirEntity());
            servicoBarba = new BarbaServico(new BarbasEntity());
        }

        // Metodo que monta o DashBoardModel com os dados necessários para a View perfil
        public DashboardModel MontaPerfil(string UserId)
        {
            var perfil = servicoPerfil.RetornaPerfilUsuario(UserId);// localiza o perfil do usuário logado

            // Recupera todos os itens seguidos usando o id do usuário
            var Seguidos = servicoSeguir.ObterSeguidos(UserId);

            // Recupera todos os seguidores do perfil
            var Seguidores = servicoSeguir.ObterSeguidores(perfil.id);

            // Recupera todas as postagens deste usuário
            var PostagensUsuario = servicoPostagem.RetornaPostagemUsuario(UserId, 5);

            // Recupera 10 postagens do banco
            var PostagensBanco = servicoPostagem.RetornaPostagens(10);

            // Recupera todas as barbas do banco
            var listaBarbas = servicoBarba.RetornaBarbas();


            // Adiciona à lista cada perfil seguido encontrado com base no id
            List<Perfil> perfisSeguidos = new List<Perfil>();
            List<Postagem> postagensSeguidos = new List<Postagem>();
            foreach (var seguido in Seguidos.Where(x => x.PerfilID != 0))
            {
                var perfilSeguido = servicoPerfil.RetornaPerfilUnico(seguido.PerfilID);
                perfisSeguidos.Add(perfilSeguido);

                // Recuperando as postagens de cada perfil seguido
                foreach (var postagemSeguido in PostagensBanco.Where(x => x.PerfilId == perfilSeguido.id))
                {
                    postagensSeguidos.Add(postagemSeguido);
                }
            }

            // Adiciona à lista cada perfil seguidor
            List<Perfil> perfisSeguidores = new List<Perfil>();
            foreach (var seguidor in Seguidores)
            {
                var perfilSeguidor = servicoPerfil.RetornaPerfilUsuario(seguidor.SeguidorId);
                perfisSeguidores.Add(perfilSeguidor);
            }

            // Convertendo Postagem em PostagemViewModel
            var PostagensSeguidosView = PostagemViewModel.GetModel(postagensSeguidos);
            // Ordenando por data
            var PostagensSeguidosOrdenadas = PostagensSeguidosView.OrderByDescending(x => x.DataPostagem).ToList();

            // Montando o DashBoard para enviar à View
            DashboardModel dashBoard = new DashboardModel();
            dashBoard.postagens = PostagemViewModel.GetModel(PostagensUsuario);
            dashBoard.postagensSeguidos = PostagensSeguidosOrdenadas;
            dashBoard.TotPostagens = servicoPostagem.TotalPostagens();
            dashBoard.PerfisSeguidos = perfisSeguidos;
            dashBoard.PerfisSeguidores = perfisSeguidores;
            dashBoard.Barbas = BarbaViewModel.GetModel(listaBarbas);
            dashBoard.nomePerfil = perfil.NomeExibicao;
            dashBoard.fotoPerfil = perfil.FotoPerfil;
            dashBoard.idPerfil = perfil.id;
            dashBoard.UserId = perfil.UserID;

            return dashBoard;
        }
    }
}