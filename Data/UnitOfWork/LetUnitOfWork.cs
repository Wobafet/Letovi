using Data.Implementacija.Interfejsi;
using Data.Implementacija.Repozitorijumi;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class LetUnitOfWork : IUnitOfWork
    {
        private LetContext context;

        public LetUnitOfWork(LetContext context)
        {
            this.context = context;
            RepositoryKorisnik = new RepositoryKorisnik(context);
            RepositoryLet = new RepositoryLet(context);
        }
        public IKorisnik RepositoryKorisnik { get; set; }
        public ILet RepositoryLet { get; set; }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
