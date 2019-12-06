using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            PracownikZamowienie = new HashSet<PracownikZamowienie>();
            ZamowienieDodatki = new HashSet<ZamowienieDodatki>();
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public int IdZamowienie { get; set; }
        public DateTime DataZamowienia { get; set; }
        public DateTime SzacowanaDataDostarczenia { get; set; }
        public string StanZamowienia { get; set; }
        public decimal CenaZamowienia { get; set; }
        public int IdUser { get; set; }
        public int IdPromocja { get; set; }

        public virtual Promocja IdPromocjaNavigation { get; set; }
        public virtual Klient IdUserNavigation { get; set; }
        public virtual ICollection<PracownikZamowienie> PracownikZamowienie { get; set; }
        public virtual ICollection<ZamowienieDodatki> ZamowienieDodatki { get; set; }
        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
