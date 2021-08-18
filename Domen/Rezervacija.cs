using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
   public  class Rezervacija
    {
        public int KorisnikId { get; set; }
        public int LetId { get; set; }
        public StatusLeta StatusLeta { get; set; }
    }
}
