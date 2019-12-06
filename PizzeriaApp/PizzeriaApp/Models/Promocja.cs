using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPromocja { get; set; }
        public DateTime ObowiazujeOd { get; set; }
        public DateTime ObowiazujeDo { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
