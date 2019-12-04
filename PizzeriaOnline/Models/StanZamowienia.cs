using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class StanZamowienia
    {
        public StanZamowienia()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdStanZamowienia { get; set; }
        public string NazwaStanu { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
