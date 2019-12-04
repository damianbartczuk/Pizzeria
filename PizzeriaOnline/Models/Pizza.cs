using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPizza { get; set; }
        public string NazwaPizzy { get; set; }
        public decimal Cena { get; set; }
        public decimal NaliczonaPromocja { get; set; }

        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
