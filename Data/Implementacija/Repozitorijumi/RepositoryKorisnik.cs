using Data.Implementacija.Interfejsi;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacija.Repozitorijumi
{
    public class RepositoryKorisnik : IKorisnik
    {
         private readonly LetContext context;
        public RepositoryKorisnik(LetContext context) => this.context = context;
        public void Add(Korisnik t)
        {
            context.Korisnik.Add(t);
        }

        public void Delete(Korisnik t)
        {
            throw new NotImplementedException();
        }

        public Korisnik Find(Predicate<Korisnik> p)
        {
            return context.Korisnik.ToList().Find(p);
        }

        public List<Korisnik> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Korisnik> GetByCondition(Predicate<Korisnik> condition)
        {
            throw new NotImplementedException();
        }
    }
}
