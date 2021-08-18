using BiznisLogika.Interfejsi;
using Data.UnitOfWork;
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

        public IUnitOfWork uow { get; set; }
    }
}
