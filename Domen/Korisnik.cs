using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Sifra { get; set; }
        public string Email { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public List<Rezervacija> Rezervacija { get; set; }
    }
}
