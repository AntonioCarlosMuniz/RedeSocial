using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio
{
    public interface IPostagemRepository
    {
        List<Postagem> ObterPostagens(int qtd);
        List<Postagem> ObterPostagensUserId(string userId, int qtd);
        void CriarPostagem(Postagem postagem);
        Postagem ObterPostagemUnica(int id);
        void EditarPostagem(Postagem postagem);
        void ApagarPostagem(Postagem barba);
        int ObterTotalPostagensGeral();
        void executaExclusao(string UserId, int PerfilId);
        void dispose();
    }
}
