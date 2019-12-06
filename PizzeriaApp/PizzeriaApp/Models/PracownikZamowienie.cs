using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class PracownikZamowienie
    {
        public int IdZamowienie { get; set; }
        public int IdPracownik { get; set; }

        public virtual Pracownik IdPracownikNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
