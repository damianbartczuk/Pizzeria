using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
            ZamowieniePracownik = new HashSet<ZamowieniePracownik>();
        }

        public int IdZamowienia { get; set; }
        public int IdPizza { get; set; }
        public DateTime DataZamowienia { get; set; }
        public int PizzaIdPizza { get; set; }
        public int StanZamowieniaIdStanZamowienia { get; set; }
        public string MiejsceDoceloweZamowienia { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual StanZamowienia StanZamowieniaIdStanZamowieniaNavigation { get; set; }
        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
        public virtual ICollection<ZamowieniePracownik> ZamowieniePracownik { get; set; }
    }
}
