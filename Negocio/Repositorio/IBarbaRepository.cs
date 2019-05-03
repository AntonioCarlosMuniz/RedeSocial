using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio
{
    public interface IBarbaRepository
    {
        List<Barba> ObterBarbas();
        bool CriarBarba(Barba barba);
        Barba ObterBarbaUnica(int id);
        void EditarBarba(Barba id);
        void ApagarBarba(Barba barba);
        void dispose();
    }
}
