using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Uzytkownik
    {
        private  string sesja;
        private  string imie;
        private  string nazwisko;
        private  string login;
        private  string email;

        public  string Sesja { get => sesja; set => sesja = value; }
        public  string Imie { get => imie; set => imie = value; }
        public  string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public  string Login { get => login; set => login = value; }
        public  string Email { get => email; set => email = value; }

        public Uzytkownik(uzytkownicy uzytkownicy, string sesja)
        {
            this.email = uzytkownicy.email;
            this.imie = uzytkownicy.imie;
            this.nazwisko = uzytkownicy.nazwisko;
            this.login = uzytkownicy.login;
            this.sesja = sesja;
        }
    }
}
