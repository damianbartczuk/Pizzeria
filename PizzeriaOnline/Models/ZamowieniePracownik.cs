using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class ZamowieniePracownik
    {
        public int PracownikIdPracownik { get; set; }
        public int ZamowienieIdZamowienia { get; set; }

        public virtual Pracownik PracownikIdPracownikNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowieniaNavigation { get; set; }
    }
}
