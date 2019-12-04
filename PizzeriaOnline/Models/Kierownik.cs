using System;
using System.Collections.Generic;

namespace PizzeriaOnline.Models
{
    public partial class Kierownik
    {
        public Kierownik()
        {
            Pracownik = new HashSet<Pracownik>();
        }

        public int IdKierownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}
