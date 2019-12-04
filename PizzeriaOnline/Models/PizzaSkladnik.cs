using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class PizzaSkladnik
    {
        public int SkladnikIdSkladnik { get; set; }
        public int PizzaIdPizza { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
