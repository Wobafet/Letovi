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

        public IUnitOfWork uow { get; set; }

        public TipKorisnika SignIn(Korisnik  korisnik)
        {

            Korisnik korisnik1 = uow.RepositoryKorisnik.Find(k => korisnik.Email == k.Email && korisnik.Sifra == k.Sifra);

            if (korisnik1 is null)
                throw new Exception("Wrong credentials");

            return korisnik1.TipKorisnika;

        }
    }
}
