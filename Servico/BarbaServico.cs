using Negocio.Dominio;
using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class BarbaServico
    {
        private IBarbaRepository repositorio { get; set; }

        public BarbaServico(IBarbaRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        //Metodo que retorna todos os perfis
        public List<Barba> RetornaBarbas()
        {
            return repositorio.ObterBarbas();
        }

        //Metodo que cria um novo perfil
        public void CriaBarba(Barba barba)
        {
            repositorio.CriarBarba(barba);
        }

        //Metodo que retorna uma barba ao receber um id
        public Barba RetornaBarbaUnica(int id)
        {
            return repositorio.ObterBarbaUnica(id);
        }

        //Metodo que edita uma barba
        public void EditaBarba(Barba barba)
        {
            repositorio.EditarBarba(barba);
        }

        //Metodo que apaga uma barba
        public void ApagaBarba(Barba barba)
        {
            repositorio.ApagarBarba(barba);
        }

        public void dispose()
        {
            repositorio.dispose();
        }
    }
}
