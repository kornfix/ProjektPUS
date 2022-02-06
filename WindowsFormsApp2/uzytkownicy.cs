using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class uzytkownicy
    {
		private string imie;
		private string nazwisko;
		private string email;
		private string login;
		private string haslo;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Email { get => email; set => email = value; }
        public string Login { get => login; set => login = value; }
        public string Haslo { get => haslo; set => haslo = value; }
    }
}
