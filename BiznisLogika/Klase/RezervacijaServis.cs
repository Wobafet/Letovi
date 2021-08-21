using BiznisLogika.Exceptions;
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
    public class RezervacijaServis : IRezervacijaServis
    {
        public RezervacijaServis(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        private IUnitOfWork uow { get; set; }
        public void Add(Rezervacija t)
        {
            var let = uow.RepositoryLet.Find(l => l.LetId == t.LetId);
            if (let.BrojMesta - t.BrojMesta < 0)
                throw new ReservationException("Nema dovoljno mesta !");

            let.BrojMesta -= t.BrojMesta;
            var rezervacija = uow.RepositoryRezervacija.Find(r => r.LetId == t.LetId && r.KorisnikId == t.KorisnikId);
            if (rezervacija is null)
                uow.RepositoryRezervacija.Add(t);
            else
                rezervacija.BrojMesta += t.BrojMesta;

            uow.Commit();
        }

        public List<Rezervacija> GetAll()
        {
            return uow.RepositoryRezervacija.FindAll();
        }

        public List<Rezervacija> GetByCondition(Predicate<Rezervacija> condition)
        {
            return uow.RepositoryRezervacija.GetByCondition(condition);
        }

        public void ChangeStatus(int letId, int korisnikId)
        {
            var rezervacija = uow.RepositoryRezervacija.Find(r => r.LetId == letId && r.KorisnikId == korisnikId);
            rezervacija.StatusLeta = StatusLeta.Odobren;
            uow.Commit();
        }

        public Rezervacija Find(Predicate<Rezervacija> condition)
        {
            return uow.RepositoryRezervacija.Find(condition);
        }
    }
}
