using Negocio.Dominio;
using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class BigodeServico
    {
        private IBigodeRepository repositorio { get; set; }

        public BigodeServico(IBigodeRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        //Metodo que retorna todos os perfis
        public List<Bigode> RetornaBigodes()
        {
            return repositorio.ObterBigodes();
        }

        //Metodo que cria um novo perfil
        public void CriaBigode(Bigode bigode)
        {
            repositorio.CriarBigode(bigode);
        }

        //Metodo que retorna um bigode ao receber um id
        public Bigode RetornaBigodeUnico(int id)
        {
            return repositorio.ObterBigodeUnico(id);
        }

        //Metodo que edita um bigode
        public void EditaBigode(Bigode bigode)
        {
            repositorio.EditarBigode(bigode);
        }

        //Metodo que apaga um bigode
        public void ApagaBigode(Bigode bigode)
        {
            repositorio.ApagarBigode(bigode);
        }

        public void dispose()
        {
            repositorio.dispose();
        }
    }
}
