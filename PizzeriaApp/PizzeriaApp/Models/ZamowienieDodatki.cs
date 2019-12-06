using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class ZamowienieDodatki
    {
        public int IdDodatek { get; set; }
        public int IdZamowienie { get; set; }
        public int Ilosc { get; set; }

        public virtual Dodatki IdDodatekNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
