using BiznisLogika.Interfejsi;
using Data.UnitOfWork;
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
    }
}
