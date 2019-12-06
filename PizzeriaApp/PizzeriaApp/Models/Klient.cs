using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdUser { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
