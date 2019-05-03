using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio
{
    public interface ISeguirRepository
    {
        void SeguirPerfil(Seguir seguir);
        void DeixarDeSeguir(string UserId, int IdSeguido);
        List<Seguir> ObterSeguidos(string userId);
        void dispose();
        bool ChecaSeguido(string UserId, int IdSeguido);
        void executaExclusao(string UserId, int PerfilId);
        List<Seguir> ObterSeguidores(int perfilId);
    }
}
