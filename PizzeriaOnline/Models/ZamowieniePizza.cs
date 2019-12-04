using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class ZamowieniePizza
    {
        public int KlientIdKlienta { get; set; }
        public int ZamowienieIdZamowienia { get; set; }

        public virtual Klient KlientIdKlientaNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowieniaNavigation { get; set; }
    }
}
