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
    public class LetServis:ILetServis
    {
        public LetServis(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        private IUnitOfWork uow { get; set; }

        public void Add(Let t)
        {
            if (t.MestoPolaska == t.MestoDolaska)
                throw new DestinationException("Destinacije moraju biti razlicite");
            if (t.Datum <= DateTime.Now)
                throw new DateException("Datum u proslosti !");

            uow.RepositoryLet.Add(t);
            uow.Commit();
        }

        public void Delete(Let t)
        {
            uow.RepositoryLet.Delete(t);
            uow.Commit();
        }

        public Let Find(Predicate<Let> condition)
        {
            return uow.RepositoryLet.Find(condition);
        }

        public List<Let> GetAll()
        {
            return uow.RepositoryLet.FindAll();
        }

        public List<Let> GetByCondition(Predicate<Let> condition)
        {
            return uow.RepositoryLet.GetByCondition(condition);
        }
    }
}
