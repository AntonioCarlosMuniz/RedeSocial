using Negocio.Dominio;
using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dados
{
    public class BarbasEntity : IBarbaRepository
    {
        SocialWebContext db = new SocialWebContext();

        public void ApagarBarba(Barba barba)
        {
            db.Barbas.Remove(barba);
            db.SaveChanges();
        }

        public void EditarBarba(Barba barba)
        {
            db.Entry(barba).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Barba> ObterBarbas()
        {
            List<Barba> perfis = db.Barbas.ToList();

            return perfis;
        }

        public bool CriarBarba(Barba barba)
        {
            try
            {
                db.Barbas.Add(barba);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Barba ObterBarbaUnica(int id)
        {
            Barba barba = db.Barbas.Find(id);
            return barba;
        }

        public void dispose()
        {
            db.Dispose();
        }
    }
}
