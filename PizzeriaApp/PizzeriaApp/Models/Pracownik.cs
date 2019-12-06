using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            PracownikZamowienie = new HashSet<PracownikZamowienie>();
        }

        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string TypPracownika { get; set; }

        public virtual ICollection<PracownikZamowienie> PracownikZamowienie { get; set; }
    }
}
