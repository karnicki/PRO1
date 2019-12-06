using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Dodatki
    {
        public Dodatki()
        {
            ZamowienieDodatki = new HashSet<ZamowienieDodatki>();
        }

        public int IdDodatek { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<ZamowienieDodatki> ZamowienieDodatki { get; set; }
    }
}
