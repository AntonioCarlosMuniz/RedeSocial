using Dados;
using Servico;
using SocialBarbaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialBarbaWeb.ServicoWeb
{
    // Classe que monta todos os dados necessários para a entidade de toda a rede
    public class FabricaPaginaGeral
    {
        private PerfilServico servicoPerfil;
        private PostagemServico servicoPostagem;

        public FabricaPaginaGeral()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
        }

        public RedeModel MontaPaginaTodaRede()
        {
            RedeModel paginaGeral = new RedeModel();
            paginaGeral.TodosOsPerfis = servicoPerfil.RetornaPerfis(16);// Obtém uma lista de perfis do banco
            var PostagensBanco = servicoPostagem.RetornaPostagens(16).ToList();// Obtém uma lista de postagens do banco
            var postagensConvertidas = PostagemViewModel.GetModel(PostagensBanco);// Converte as postagens de 'Postagem' para 'PostViewModel'
            paginaGeral.TodasAsPostagens = postagensConvertidas;// Adiciona a lista de postagens convertidas à entidade 'TodaRedeModel'

            return paginaGeral;
        }
    }
}