using Data.Implementacija.Interfejsi;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacija.Repozitorijumi
{
    public class RepositoryRezervacija : IRezervacija
    {
        private readonly LetContext context;
        public RepositoryRezervacija(LetContext context) => this.context = context;
        public void Add(Rezervacija t)
        {
            context.Rezervacija.Add(t);                            
        }

        public Rezervacija Find(Predicate<Rezervacija> p)
        {
            return context.Rezervacija.Include(r=>r.Korisnik).Include(r=>r.Let).ToList().Find(p);
        }

        public List<Rezervacija> FindAll()
        {
            return context.Rezervacija.Include(r=>r.Korisnik).Include(r=>r.Let).ToList();
        }

        public List<Rezervacija> GetByCondition(Predicate<Rezervacija> condition)
        {
            return context.Rezervacija.Include(r => r.Korisnik).Include(r => r.Let).ToList().FindAll(condition);
        }
    }
}
