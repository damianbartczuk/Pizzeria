using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            ZamowieniePracownik = new HashSet<ZamowieniePracownik>();
        }

        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Haslo { get; set; }
        public int KierownikIdKierownika { get; set; }

        public virtual Kierownik KierownikIdKierownikaNavigation { get; set; }
        public virtual ICollection<ZamowieniePracownik> ZamowieniePracownik { get; set; }
    }
}
