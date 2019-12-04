using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class Klient
    {
        public Klient()
        {
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public int IdKlienta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaKlienta { get; set; }
        public string Haslo { get; set; }

        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
