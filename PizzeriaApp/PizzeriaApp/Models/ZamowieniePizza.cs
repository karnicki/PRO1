using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class ZamowieniePizza
    {
        public int IdPizza { get; set; }
        public int IdZamowienie { get; set; }
        public int Ilosc { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
