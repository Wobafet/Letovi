using BiznisLogika.Interfejsi;
using Data.UnitOfWork;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznisLogika.Klase
{
   public class KorisnikServis:IKorsnikServis

    {
        public KorisnikServis(IUnitOfWork uow)
        {
            //this.uow = new EShopUnitOfWork(new ShopContext());
            this.uow = uow;
        }

        private IUnitOfWork uow { get; set; }

        public Korisnik SignIn(Korisnik  korisnik)
        {

            Korisnik korisnik1 = uow.RepositoryKorisnik.Find(k => korisnik.Email == k.Email && korisnik.Sifra == k.Sifra);

            if (korisnik1 is null)
                throw new Exception("Wrong credentials");

            return korisnik1;

        }

        public void Add(Korisnik t)
        {
            uow.RepositoryKorisnik.Add(t);
            uow.Commit();
        }

        public List<Korisnik> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Korisnik> GetByCondition(Predicate<Korisnik> condition)
        {
            throw new NotImplementedException();
        }

        public Korisnik Find(Predicate<Korisnik> condition)
        {
            throw new NotImplementedException();
        }

        public void Delete(Korisnik t)
        {
            throw new NotImplementedException();
        }
    }
}
