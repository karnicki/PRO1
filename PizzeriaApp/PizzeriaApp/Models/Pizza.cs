using System;
using System.Collections.Generic;

namespace PizzeriaApp.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public int Srednica { get; set; }

        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
