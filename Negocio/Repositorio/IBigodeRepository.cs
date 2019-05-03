using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio
{
    public interface IBigodeRepository
    {
        List<Bigode> ObterBigodes();
        bool CriarBigode(Bigode bigode);
        Bigode ObterBigodeUnico(int id);
        void EditarBigode(Bigode id);
        void ApagarBigode(Bigode bigode);
        void dispose();
    }
}
