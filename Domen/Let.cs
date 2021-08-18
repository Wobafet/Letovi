using System;

namespace Domen
{
    public class Let
    {
        public int LetId { get; set; }
        public Mesto MestoPolaska { get; set; }
        public Mesto MestoDolaska { get; set; }
        public DateTime Datum { get; set; }
        public int BrojPresedanja { get; set; }
        public int BrojMesta { get; set; }
    }
}
