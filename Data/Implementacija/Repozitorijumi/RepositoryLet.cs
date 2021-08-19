using Data.Implementacija.Interfejsi;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacija.Repozitorijumi
{
    public class RepositoryLet : ILet
    {
        private readonly LetContext context;
        public RepositoryLet(LetContext context) => this.context = context;
        public void Add(Let t)
        {
            context.Let.Add(t);
        }

        public Let Find(Predicate<Let> p)
        {
            throw new NotImplementedException();
        }

        public List<Let> FindAll()
        {
            return context.Let.ToList();
        }
    }
}
