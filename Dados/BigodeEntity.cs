using Negocio.Dominio;
using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class BigodeEntity : IBigodeRepository
    {
        SocialWebContext db = new SocialWebContext();

        public void ApagarBigode(Bigode bigode)
        {
            db.Bigodes.Remove(bigode);
            db.SaveChanges();
        }

        public void EditarBigode(Bigode bigode)
        {
            db.Entry(bigode).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Bigode ObterBigodeUnico(int id)
        {
            Bigode bigode = db.Bigodes.Find(id);

            return bigode;
        }

        public List<Bigode> ObterBigodes()
        {
            List<Bigode> bigode = db.Bigodes.ToList();

            return bigode;
        }

        public bool CriarBigode(Bigode bigode)
        {
            try
            {
                db.Bigodes.Add(bigode);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public void dispose()
        {
            db.Dispose();
        }
    }
}
